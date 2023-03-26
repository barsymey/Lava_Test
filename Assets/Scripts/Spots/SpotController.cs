using UnityEngine;

/// <summary> An object where resourchs can be transfered for refining. </summary>
public class SpotController : MonoBehaviour, IResourceReciever
{
    [SerializeField]SpotProps props;
    [SerializeField] float processingTime;
    Inventory _inventory;
    IResourceEmitter _spawner;
    ResourceProcessor _processor;
    float _nextRecieveTime;

    void Start()
    {
        _spawner = GetComponentInChildren<IResourceEmitter>();
        _inventory = new Inventory();
        _processor = new ResourceProcessor(processingTime, props.recipe, _spawner, _inventory);
    }

    void FixedUpdate()
    {
        _processor.UpdateProcessor();
    }

/// <summary> Check for intake delay. </summary>
    public bool IsReadyToRecieveResource()
    {
        bool timePassed = Time.timeSinceLevelLoad > _nextRecieveTime;
        if(timePassed)
            _nextRecieveTime = Time.timeSinceLevelLoad + props.intakeDelay;
        return timePassed;
    }

/// <summary> Returns resources required for refining </summary>
    public SpotRecipeItem[] GetAcceptableResources()
    {
        return props.recipe.GetRequiredResources();
    }

    public void RecieveResource(ResourceType type)
    {
        _inventory.AddResource(type, 1);
    }
}
