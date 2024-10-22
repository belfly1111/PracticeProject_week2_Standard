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

        GameObject curObj = pool[key].Dequeue();
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
}