using UnityEngine;

/// <summary> Resource scene object behaviour. </summary>
public class ResourceObject : MonoBehaviour, IPickableResource
{
    [SerializeField]public ResourceProps props;

    Rigidbody _rigidbody;
/// <summary> Transform of an object that resource will flow to when time comes. </summary>
    Transform _recieverTransform;
    IResourceReciever _reciever;
    float _pickupEnableTime;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _pickupEnableTime = Time.timeSinceLevelLoad + props.pickupTime;
        GetComponent<SphereCollider>().radius = props.pickupDistance;
    }

    void Update()
    {
        if(_reciever == null || Time.timeSinceLevelLoad < _pickupEnableTime)
            return;
        FlyTowardsReciever();
    }

/////////////

    public void Pick(GameObject picker)
    {
        if(!CanBePicked())
            return;
        AssignPicker(picker);
    }

    public void AssignPicker(GameObject picker)
    {
        _recieverTransform = picker.transform;
        _reciever = picker.GetComponent<IResourceReciever>();
    }

//////////////

    void FlyTowardsReciever()
    {
        transform.position = Vector3.MoveTowards(transform.position, _recieverTransform.position, 10 * Time.deltaTime);
        _rigidbody.isKinematic = true;
        if(Vector3.Distance(transform.position, _recieverTransform.position) < 0.2)
        {
            _reciever.RecieveResource(props.type);
            Destroy(gameObject);
        }
    }

    bool CanBePicked()
    {
        return Time.timeSinceLevelLoad > _pickupEnableTime && _reciever == null;
    }
}
