using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    private List<GameObject> pool = new List<GameObject>();
    public int poolSize = 300;

    private void Awake()
    {
        
    }

    void Start()
    {
        InitializePool();
    }

    private void InitializePool()
    {

    }

    public GameObject Get()
    {
        
    }

    public void Release(GameObject obj)
    {
        
    }
}

