using System;
using UnityEngine;

/// <summary> An element of Quest sequence </summary>
[Serializable]
public class QuestStage
{
    // Pretty basic. Can only track resource based conditions
    public string questLine;
    public ResourceType resourceType;
    public QuestStageType questStageType;
    public int targetAmount;
    public Transform target;

    bool _isCompleted = false;
    bool _isActive = false;

    ~QuestStage()
    {
        GameObject.FindObjectOfType<GameLogic>().GetInventoryReference().InventoryChanged -= MineCheck;
    }

    /// <summary> To be called from parent Quest on quest started </summary>
    public void InitStage()
    {
        _isActive = false;
        GameObject.FindObjectOfType<GameLogic>().GetInventoryReference().InventoryChanged += MineCheck;
    }

    public bool IsCompleted()
    {
        return _isCompleted;
    }

    /// <summary> For consecutive control pf quests order </summary>
    public void SetActive(bool state)
    {
        _isActive = state;
    }

    void MineCheck(int[] resources)
    {
        if(_isCompleted || !_isActive)
            return;
        if(questStageType == QuestStageType.Mine)
            _isCompleted = resources[(int)resourceType] >= targetAmount;
        else if(questStageType == QuestStageType.Drop)
            _isCompleted = resources[(int)resourceType] <= targetAmount;
    }


}

[Serializable]
public enum QuestStageType
{
    Mine,
    Drop
}