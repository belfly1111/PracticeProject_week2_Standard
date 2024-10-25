using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<QuestDataSO> Quests;

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

    private void Start()
    {
        PrintQuestInfo();
    }

    private void PrintQuestInfo()
    {
        foreach (var quest in Quests)
        {
            if (quest is MonsterQuestDataSO monsterQuest)
            {
                Debug.Log($"{monsterQuest.TargetMonsterName}를 {monsterQuest.MonsterCount}마리 소탕");
            }
            else if (quest is EncounterQuestDataSO encounterQuest)
            {
                Debug.Log($"{encounterQuest.TargetNPCName}과 대화하기");
            }
            else
            {
            }
        }
    }
}
