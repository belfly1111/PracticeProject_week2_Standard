using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private static QuestManager instance;
    public static QuestManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<QuestManager>();
                if(instance == null)
                {
                    new GameObject("QuestManager").AddComponent<QuestManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
