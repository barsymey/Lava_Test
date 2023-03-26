using UnityEngine;
using UnityEngine.UI;

/// <summary> Core quest UI element. Contains description of a quest and its stages. </summary>
public class ActiveQuestPanel : MonoBehaviour
{

    [SerializeField]Text questLabel;
    [SerializeField]QuestStagePanel questStagePanel;
    Quest _activeQuest;

    public void SetActiveQuest(Quest quest)
    {
        _activeQuest = quest;
        InitQuestPanel();
    }

/// <summary> Manual update. Keeping QuestStages representation actual </summary>
    public void UpdateQuestPanel()
    {
        questStagePanel.UpdateQuestStagePanel();
    }

    public void ClearPanel()
    {
        questLabel.text = string.Empty;
        questStagePanel.ClearPanel();
    }

    void InitQuestPanel()
    {
        questLabel.text = _activeQuest.questName;
        questStagePanel.ClearPanel();
        questStagePanel.SetActiveQuest(_activeQuest);
    }
}
