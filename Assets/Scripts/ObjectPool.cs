using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public ObjectCase[] objectCases;
    public Dictionary<string, Queue<GameObject>> pool;

    void Start()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        pool = new Dictionary<string, Queue<GameObject>>();
        
        for(int i = 0; i < objectCases.Length; i++)
        {
            string key = objectCases[i].GO.name;

            if (!pool.ContainsKey(key))
            {
                pool.Add(key, new Queue<GameObject>());
            }

            for(int j = 0;  j < objectCases[i].count; j++)
            {
                GameObject curObj = Instantiate(objectCases[i].GO);
                curObj.name = objectCases[i].GO.name;

                curObj.SetActive(false);
                pool[key].Enqueue(curObj);
            }
        }
    }

    public GameObject Get(string key)
    {
        // 해당 오브젝트가 존재하지 않을 경우 null을 리턴함. 
        if (!pool.ContainsKey(key))
        {
            return null;
        }

        GameObject curObj;

        // 부족할 경우 더 채워준다!
        if (pool[key].Count == 0)
        {
            // 해당 키의 ObjectCase를 찾아서 새로운 객체를 생성
            ObjectCase objectCase = Array.Find(objectCases, oc => oc.GO.name == key);
            if (objectCase != null)
            {
                curObj = Instantiate(objectCase.GO);
                curObj.name = objectCase.GO.name;
            }
            else
            {
                return null;
            }
        }
        else
        {
            curObj = pool[key].Dequeue();
        }

        curObj.SetActive(true);
        return curObj;
    }

    public void Release(GameObject obj)
    {
        // 해당 오브젝트가 존재하지 않을 경우 null을 리턴함. 
        if (!pool.ContainsKey(obj.name))
        {
            return;
        }

        obj.SetActive(false);
        pool[obj.name].Enqueue(obj);
    }

    public void GetRNBtn()
    {
        int randomNum = UnityEngine.Random.Range(0, objectCases.Length);
        string randomName = objectCases[randomNum].GO.name;
        Get(randomName);
    }

    public void ReleaseRNBtn()
    {
        int randomNum = UnityEngine.Random.Range(0, objectCases.Length);
        string randomName = objectCases[randomNum].GO.name;
        GameObject randomGO = GameObject.Find(randomName);

        if (randomGO == null) return;
        Release(randomGO);
    }
}