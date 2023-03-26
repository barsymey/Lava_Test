using DG.Tweening;
using UnityEngine;

/// <summary> Resource node animation controller. Animated with DOTween. </summary>
public class NodeVisualController : MonoBehaviour
{
    public void Mine()
    {
        transform.localScale = Vector3.one;
        transform.DOPunchScale(Vector3.one * 0.7f, 1, elasticity:0.1f, vibrato:10);
    }

    public void Depleete()
    {
        transform.DOScale(0, 0.2f).SetEase(Ease.InElastic);
    }

    public void Respawn()
    {
        transform.DOScale(1, 1).SetEase(Ease.InOutElastic);
    }
}
