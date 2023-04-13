using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private int _spawnPosX_1 = 1;
    [SerializeField] private int _spawnPosX_2 = 6;
    [SerializeField] private int _spawnPosZ_1 = 1;
    [SerializeField] private int _spawnPosZ_2 = 6;
    [SerializeField] private float _teleportInterval = 5.0f;
    [SerializeField] private float _nextTeleport = 0.0f;

    private void Start()
    {
        _nextTeleport = 0.0f;
    }

    private void Update()
    {
        if (Time.time > _nextTeleport)
        {
            _nextTeleport = Time.time + _teleportInterval;
            transform.position = GenerateSpawnPosition();
        } 
    }

    private Vector3 GenerateSpawnPosition()
    {
        int spawnPosX = Random.Range(_spawnPosX_1, _spawnPosX_2 + 1);
        int spawnPosZ = Random.Range(_spawnPosZ_1, _spawnPosZ_2 + 1);
        Vector3 spawnPos = new(spawnPosX, 0.0f, spawnPosZ);
        Debug.Log(spawnPos);
        return spawnPos;      
    }
}
