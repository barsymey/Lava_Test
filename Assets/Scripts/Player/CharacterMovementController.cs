using UnityEngine;
using UnityEngine.AI;

/// <summary> Controls character movement via NavMesh </summary>
public class CharacterMovementController : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    float _verticalMovement;
    float _horizontalMovement;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

/// <summary> Set destination for NavMesh </summary>
    public void Control(Vector3 destination)
    {
        _horizontalMovement = destination.x;
        _verticalMovement = destination.z;
        _navMeshAgent.SetDestination(transform.position + destination);
    }

    public bool IsMoving()
    {
        return _horizontalMovement != 0 && _verticalMovement != 0;
    }
}
