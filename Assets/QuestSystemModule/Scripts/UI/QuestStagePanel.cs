using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> A container for QuestStages representation </summary>
public class QuestStagePanel : MonoBehaviour
{
    [SerializeField]GameObject questStagePrefab;
    Quest _activeQuest;

    public void ClearPanel()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i));
        }
    }

    public void SetActiveQuest(Quest quest)
    {
        _activeQuest = quest;
        CreateQuestStageItems();
    }

/// <summary> Marking completed quest stages. </summary>
    public void UpdateQuestStagePanel()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<QuestStageItem>().SetActiveState(_activeQuest.stages[i].IsCompleted());
        }
    }

    void CreateQuestStageItems()
    {
        foreach(QuestStage stage in _activeQuest.stages)
        {
            GameObject item = Instantiate(questStagePrefab, transform);
            item.GetComponent<QuestStageItem>().SetText(stage.questLine);
        }
    }
}
