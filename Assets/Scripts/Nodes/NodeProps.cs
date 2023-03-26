using UnityEngine;

[CreateAssetMenu(fileName = "NewNodeProps")]
/// <summary> Scriptable object for adjusting resource node properties. </summary>
public class NodeProps : ScriptableObject
{
    [SerializeField]public ResourceType type;
    [SerializeField]public float mineDelay;
    [SerializeField]public int resourcesAmountPerMine;
    [SerializeField]public float respawnTime;
    [SerializeField]public int hitsBeforeDepleeted;

}
