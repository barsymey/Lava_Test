using UnityEngine;

/// <summary> An on-screen UI marker pointing to targeted object on a scene </summary>
public class QuestMarker : MonoBehaviour
{
    Transform _target;

    void Update()
    {
        PointToTarget();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
        gameObject.SetActive(target != null);
    }

    private void PointToTarget()
    {
        if(_target == null)
            return;
        try
        {
            Vector3 targetScreenPos = Camera.current.WorldToScreenPoint(_target.position);

            transform.position = new Vector3(
                Mathf.Clamp(targetScreenPos.x, 0, Camera.current.pixelWidth),
                Mathf.Clamp(targetScreenPos.y, 0, Camera.current.pixelHeight),
                targetScreenPos.z
            );
        }
        catch{
            Debug.Log("ad");
        }
    }
}
