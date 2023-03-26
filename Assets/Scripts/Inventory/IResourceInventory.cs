/// <summary> Basic resource inventory interaction </summary>
public interface IResourceInventory
{
    void AddResource(ResourceType type, int amount);
    void RemoveResource(ResourceType type, int amount);
    public int GetAmount(ResourceType type);
}
