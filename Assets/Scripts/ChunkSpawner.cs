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
        LevelChunk newChunk = _chunks[Random.Range(0, _chunks.Length)];
        Vector3 spawnPosition = new Vector3((_currentChunk.Position.x + _currentChunk.Size.x / 2f) + (newChunk.Size.x / 2f),
                                             _currentChunk.Position.y,
                                             _currentChunk.Position.z);
        _currentChunk = Instantiate(newChunk, spawnPosition, Quaternion.identity);
        _spawnThreshold += newChunk.Size.x;
    }

	private void OnDrawGizmos()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(_spawnThreshold, -5, 0), new Vector3(_spawnThreshold, 5, 0));
	}
}
