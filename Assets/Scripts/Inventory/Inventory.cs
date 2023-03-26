using System;

/// <summary> Resource storage </summary>
public class Inventory : IResourceInventory
{
    int[] _resourceQuantityArray;
    public Action<int[]> InventoryChanged;
    
    public Inventory()
    {
        _resourceQuantityArray = new int[Enum.GetValues(typeof(ResourceType)).Length];
    }

    public void AddResource(ResourceType type, int amount)
    {
        _resourceQuantityArray[(int)type] += amount;
        if(_resourceQuantityArray[(int)type] > int.MaxValue - 1)
            _resourceQuantityArray[(int)type] = int.MaxValue - 1;
        OnInventoryChanged();
    }

    public void RemoveResource(ResourceType type, int amount)
    {
        _resourceQuantityArray[(int)type] -= amount;
        if(_resourceQuantityArray[(int)type] < 0)
            _resourceQuantityArray[(int)type] = 0;
        OnInventoryChanged();
    }

    public int GetAmount(ResourceType type)
    {
        return _resourceQuantityArray[(int)type];
    }

/// <summary> Setting inventory data from given array. Works even if new resource types were added since last save. </summary>
    public void SetInventoryData(int[] data)
    {
        for(int i = 0; i < _resourceQuantityArray.Length && i < data.Length; i++)
            _resourceQuantityArray[i] = data[i];
        if(InventoryChanged != null)
            InventoryChanged.Invoke(_resourceQuantityArray);
    }

    public int[] GetInventoryData()
    {
        return _resourceQuantityArray;
    }

    void OnInventoryChanged()
    {
        if(InventoryChanged != null)
            InventoryChanged.Invoke(_resourceQuantityArray);
    }
}
