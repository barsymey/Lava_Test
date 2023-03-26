using UnityEngine;

/// <summary> An object that emits resource objects. </summary>
public class ResourceSpawner : MonoBehaviour, IResourceEmitter
{
    ResourceObjectsTypeMapper _mapper;

    void Awake()
    {
        _mapper = GameObject.FindObjectOfType<ResourceObjectsTypeMapper>();
    }

/// <summary> Spawn resource object in direction of transform.forward with impulse and spread set in resource object properties. </summary>
    public IPickableResource SpawnObject(ResourceType types)
    {
        GameObject resource = Instantiate(_mapper.GetResObjectOfType(types), transform.position, transform.rotation);
        ResourceObject resourceObject = resource.GetComponent<ResourceObject>();
        resource.GetComponent<Rigidbody>().AddForce((transform.forward * resourceObject.props.impulse) + new Vector3(
            Random.Range(-resourceObject.props.spread, resourceObject.props.spread),
            0,
            Random.Range(-resourceObject.props.spread, resourceObject.props.spread)
        ), ForceMode.Impulse);
        return resource.GetComponent<IPickableResource>();
    }
}
