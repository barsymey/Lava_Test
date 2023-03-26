using UnityEngine;

/// <summary> Controls base UI. Only manages resource inventory representation for now. </summary>
public class UIController : MonoBehaviour
{
    [SerializeField]public UIInventory inventoryUI;
    
    void Awake()
    {
        GameObject.FindObjectOfType<GameLogic>().GetInventoryReference().InventoryChanged += inventoryUI.UpdateInventory;
    }
}
