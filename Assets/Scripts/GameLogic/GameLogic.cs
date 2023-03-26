using UnityEngine;

/// <summary> Core level logic. Manages player controls and inventory state </summary>
public class GameLogic : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform playerSpawn;

    PlayerController _player;
    PlayerInput _playerInput;
    Inventory _inventory;
    SaveSystem _saveSystem;
    CameraController _cameraController;

    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _cameraController = GetComponent<CameraController>();
        _saveSystem = new SaveSystem();
        _inventory = new Inventory();
        _inventory.InventoryChanged += SaveGame;
    }

    void Start()
    {
        StartLevel();
    }

    void StartLevel()
    {
        _inventory.SetInventoryData(_saveSystem.LoadInventoryData());

        SpawnPlayer();
    }

    public Inventory GetInventoryReference()
    {
        return _inventory;
    }

    public void SaveGame(int[] data)
    {
        _saveSystem.SaveInventoryData(data);
    }

/// <summary> Spawning player, attaching inventory, camera and input system to it. </summary>
    void SpawnPlayer()
    {
        GameObject playerObject;
        if(!playerSpawn)
        {
            Debug.LogWarning("No player spawn defined. Spawning player at world origin.");
            playerObject = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        }
        else
            playerObject = Instantiate(playerPrefab, playerSpawn.transform.position, playerSpawn.transform.rotation);

        _player = playerObject.GetComponent<PlayerController>();

        _player.AttachInventory(_inventory);
        _playerInput.SetControllableChatacter(_player);
        _cameraController.SetCameraTarget(playerObject.transform);
    }
}
