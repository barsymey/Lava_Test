using UnityEngine;

/// <summary> Tracks Quest condition and manages UI </summary>
public class QuestSystemCore : MonoBehaviour
{
    public Quest currentQuest;
    [SerializeField]QuestMarker marker;
    [SerializeField]ActiveQuestPanel questPanel;

    void Start()
    {
        questPanel.SetActiveQuest(currentQuest);
        currentQuest.StartQuest();
    }

    void FixedUpdate()
    {
        if(currentQuest.IsCompleted())
            marker.SetTarget(null);
        else
            marker.SetTarget(currentQuest.GetCurrentStage().target);

        currentQuest.UpdateQuest();
        questPanel.UpdateQuestPanel();
    }
    
}
