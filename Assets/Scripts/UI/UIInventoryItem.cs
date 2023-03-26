using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary> UI item representing separate resource. </summary>
public class UIInventoryItem : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] Text amountText;

    int _currentAmount;
    ResourceType _type;

    public void Init(ResourceType type)
    {
        _type = type;
        icon.sprite = FindObjectOfType<ResourceObjectsTypeMapper>().GetResIcon(_type);
        SetAmount(0);
    }

/// <summary> Set text to amount and perform visual reaction. </summary>
    public void SetAmount(int amount)
    {
        amountText.text = amount.ToString();
        if(amount <= 0)
            gameObject.SetActive(false);
        else
            gameObject.SetActive(true);

        if(_currentAmount < amount)
        {
            transform.DOKill();
            transform.localScale = Vector3.one;
            transform.DOPunchScale(Vector3.one * 1.1f, 0.2f, elasticity:0.1f);
        }
        _currentAmount = amount;
    }


}
