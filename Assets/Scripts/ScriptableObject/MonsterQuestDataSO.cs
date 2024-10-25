using UnityEngine;

[CreateAssetMenu(fileName = "MonsterQuestDataSO", menuName = "Scriptable Object/MonsterQuestData", order = int.MaxValue)]

public class MonsterQuestDataSO : QuestDataSO
{
    public string TargetMonsterName;
    public int MonsterCount;
}
