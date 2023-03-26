using UnityEngine;


public class ResourceNodeController : MonoBehaviour
{
    [SerializeField]NodeProps props;
    
    IResourceEmitter _spawner;
    NodeVisualController _visual;
    int _currentHitsLeft = 3;
    float _nextMineTime = 0;
    float _nextSpawnTime = 0;
    bool _isRespawning;

    void Start()
    {
        _spawner = GetComponentInChildren<IResourceEmitter>();
        _currentHitsLeft = props.hitsBeforeDepleeted;
        _isRespawning = false;
        _visual = GetComponentInChildren<NodeVisualController>();
    }

/// <summary> Mine resource node if it is ready to be mined. </summary>
    public void MineResource()
    {
        if(_isRespawning || _nextMineTime > Time.timeSinceLevelLoad)
            return;

        _nextMineTime = Time.timeSinceLevelLoad + props.mineDelay;
        _currentHitsLeft--;
        for(int i = 0; i < props.resourcesAmountPerMine; i++)
            _spawner.SpawnObject(props.type);

        if(_currentHitsLeft <= 0)
        {
            _isRespawning = true;
            _nextSpawnTime = Time.timeSinceLevelLoad + props.respawnTime;
            _visual.Depleete();
            return;
        }
        _visual.Mine();
    }

    void FixedUpdate()
    {
        if(_isRespawning && _nextSpawnTime < Time.timeSinceLevelLoad)
        {
            _isRespawning = false;
            _currentHitsLeft = props.hitsBeforeDepleeted;
            _visual.Respawn();
        }
    }
}
