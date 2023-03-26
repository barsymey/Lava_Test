using UnityEngine;

/// <summary> Player character controller and joystick linkage. </summary>
public class PlayerInput : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    CharacterMovementController _movementController;


    public void SetControllableChatacter(PlayerController player)
    {
        _movementController = player.GetMovementController();
    }

    void Update()
    {
        _movementController.Control(new Vector3(joystick.Horizontal, 0, joystick.Vertical));
    }
}
