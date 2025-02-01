using UnityEngine;

public class FlagHandler : MonoBehaviour
{
    [SerializeField] private Flag _flagPrefab;
    [SerializeField] private BaseSpawner _baseSpawner;

    private Flag _spawnedFlag;

    public bool IsFlagSet { get; private set; } = false;
    public Flag Flag => _spawnedFlag;

    private void Awake()
    {
        _flagPrefab.OnDisable += SetFlagToNull;
    }

    private void OnDestroy()
    {
        _flagPrefab.OnDisable -= SetFlagToNull;
    }

    public void SetFlag(Vector3 position)
    {
        if (IsFlagSet)
        {
            SetFlagPosition(position);
        }
        else
        {
            IsFlagSet = true;
            _spawnedFlag = SpawnFlag(position);
        }
    }

    public Flag GetFlag()
    {
        return _spawnedFlag;
    }

    public void SetFlagPosition(Vector3 position)
    {
        _spawnedFlag.gameObject.SetActive(true);
        _spawnedFlag.transform.position = position;
    }

    public Flag SpawnFlag(Vector3 position)
    {
        return Instantiate(_flagPrefab, position, Quaternion.identity);
    }

    private void SetFlagToNull()
    {
        IsFlagSet = false;
    }
}
