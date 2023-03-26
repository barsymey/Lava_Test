using UnityEngine;

[CreateAssetMenu(fileName = "NewResourceProps")]
/// <summary> Scriptable object for adjusting resource properties. </summary>
public class ResourceProps : ScriptableObject
{
    public ResourceType type;
    public float pickupTime = 1;
    public float pickupDistance = 3;
    public float impulse = 1;
    public float spread = 1;
}
