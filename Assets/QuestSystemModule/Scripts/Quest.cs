using System;

[Serializable]
/// <summary> Entity tracking completion state of its stages and itself </summary>
public class Quest
{
    public string questName;
    public QuestStage[] stages;

    int _currentStage;
    bool _isCompleted;

    public void StartQuest()
    {
        _isCompleted = false;
        _currentStage = 0;
        foreach(QuestStage stage in stages)
            stage.InitStage();
    }

/// <summary> Manual update </summary>
    public void UpdateQuest()
    {
        for(int i = 0; i < stages.Length; i++)
        {
            if(!stages[i].IsCompleted())
            {
                _currentStage = i;
                stages[i].SetActive(true);
                return;
            }
        }
        _isCompleted = true;
    }

    public QuestStage GetCurrentStage()
    {
        return stages[_currentStage];
    }

    public bool IsCompleted()
    {
        return _isCompleted;
    }
}
