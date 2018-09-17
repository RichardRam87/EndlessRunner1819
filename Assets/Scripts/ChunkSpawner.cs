using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour 
{
    [SerializeField]
    private LevelChunk[] _chunks;

    [SerializeField]
    private float _spawnThreshold;

    private Transform _player;
    private LevelChunk _currentChunk;

	private void Awake()
	{
        _player = GameObject.FindWithTag("Player").transform;
	}

	private void Start()
	{
        _currentChunk = FindObjectOfType<LevelChunk>();
	}
	private void Update()
	{
        if (_spawnThreshold > _player.position.x) return;

        SpawnChunk();
 	}

    void SpawnChunk()
    {
        LevelChunk chunk = _chunks[Random.Range(0, _chunks.Length)];
        Vector3 spawnPosition = new Vector3(_currentChunk.transform.position.x,
                                            _currentChunk.transform.position.y,
                                            _currentChunk.transform.position.z);
        Instantiate(chunk, spawnPosition, Quaternion.identity);
        _spawnThreshold += chunk.Size.x;

        print("Spawn");
    }

	private void OnDrawGizmos()
	{
        Gizmos.DrawLine(new Vector3(_spawnThreshold, -5, 0), new Vector3(_spawnThreshold, 5, 0));
	}
}
