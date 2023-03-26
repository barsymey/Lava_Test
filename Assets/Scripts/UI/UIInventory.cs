using System;
using UnityEngine;

/// <summary> UI container for resource inventory indication. </summary>
public class UIInventory : MonoBehaviour
{
    [SerializeField]GameObject itemPrefab;
    void Awake()
    {
        foreach(ResourceType t in Enum.GetValues(typeof(ResourceType)))
        {
            GameObject item = Instantiate(itemPrefab, transform);
            item.GetComponent<UIInventoryItem>().Init(t);
        }
    }

/// <summary> Manual update resource values. </summary>
    public void UpdateInventory(int[] data)
    {
        for(int i = 0; i < data.Length; i++)
        {
            transform.GetChild(i).GetComponent<UIInventoryItem>().SetAmount(data[i]);
        }
    }
}
