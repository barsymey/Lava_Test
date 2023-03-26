using UnityEngine;

/// <summary> Manages interaction with other objects, and player input </summary>
public class PlayerController : MonoBehaviour, IResourceReciever
{
    CharacterMovementController _movementController;
    Inventory _inventory;
    IResourceEmitter _spawner;

    void Awake()
    {
        _movementController = GetComponent<CharacterMovementController>();
        _spawner = GetComponentInChildren<ResourceSpawner>();
    }

    void OnTriggerStay(Collider other)
    {
        PickResource(other.gameObject);
        MineNode(other.gameObject);
        TransferResource(other.gameObject);
    }



///////////

    public void RecieveResource(ResourceType type)
    {
        _inventory.AddResource(type, 1);
    }

    public void AttachInventory(Inventory inventory)
    {
        _inventory = inventory;
    }

    public CharacterMovementController GetMovementController()
    {
        return _movementController;
    }

//////////

    void MineNode(GameObject nodeObject)
    {
        ResourceNodeController node;
        if(nodeObject.TryGetComponent<ResourceNodeController>(out node))
        {
            node.MineResource();
        }
    }

    void PickResource(GameObject resourceObject)
    {
        IPickableResource resource;
        if(resourceObject.TryGetComponent<IPickableResource>(out resource))
        {
            resource.Pick(gameObject);
        }
    }

    void TransferResource(GameObject spotObject)
    {
        if(_movementController.IsMoving())
            return;
        SpotController spot;
        if(spotObject.TryGetComponent<SpotController>(out spot))
        {
            if(spot.IsReadyToRecieveResource())
                foreach(SpotRecipeItem item in spot.GetAcceptableResources())
                {
                    if(_inventory.GetAmount(item.type) > 0)
                    {
                        _spawner.SpawnObject(item.type).AssignPicker(spotObject);
                        _inventory.RemoveResource(item.type, 1);
                        return;
                    }
                }
        }
    }
}
