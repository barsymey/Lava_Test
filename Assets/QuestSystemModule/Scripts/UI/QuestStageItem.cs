using UnityEngine;
using UnityEngine.UI;

/// <summary> QuestStage UI representation </summary>
public class QuestStageItem : MonoBehaviour
{
    public Text stageText;

    private Color _activeColor = Color.white;
    private Color _completedColor = new Color(0.7f, 0.7f, 0.7f, 1);

    public void SetText(string questLine)
    {
        stageText.text = questLine;
    }

/// <summary> Changing color depending on state </summary>
    public void SetActiveState(bool state)
    {
        if(state)
            stageText.color = _activeColor;
        else
            stageText.color = _completedColor;
    }
}
