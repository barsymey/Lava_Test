using UnityEngine;
using Cinemachine;

/// <summary> Stores cinemachine camera for easy target attachment </summary>
public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;

    public void SetCameraTarget(Transform target)
    {
        virtualCamera.Follow = target;
        virtualCamera.LookAt = target;
    }
}
