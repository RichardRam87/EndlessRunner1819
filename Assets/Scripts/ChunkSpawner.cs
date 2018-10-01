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
    private ChunkContainer _chunkContainer;

	private void Awake()
	{
        _player = GameObject.FindWithTag("Player").transform;
	}

	private void Start()
	{
        _chunkContainer = GetComponent<ChunkContainer>();
	}

	private void Update()
	{
        if (_spawnThreshold > _player.position.x) return;

        SpawnChunk();
 	}

    void SpawnChunk()
    {
		LevelChunk currentChunk = _chunkContainer.CurrentChunk;
        LevelChunk newChunk;
        do
        {
            newChunk = _chunks[Random.Range(0, _chunks.Length)];
        } while (_chunkContainer.HasChunkColor(newChunk.ChunkColor) && !_chunkContainer.HasAllColors());

        Vector3 spawnPosition = new Vector3((currentChunk.Position.x + currentChunk.Size.x / 2f) + (newChunk.Size.x / 2f),
                                             currentChunk.Position.y,
                                             currentChunk.Position.z);
        
        LevelChunk nextChunk = Instantiate(newChunk, spawnPosition, Quaternion.identity);

        _chunkContainer.AddChunk(nextChunk);
        _spawnThreshold += nextChunk.Size.x;

        nextChunk.transform.SetParent(transform);
    }

	private void OnDrawGizmos()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(_spawnThreshold, -5, 0), new Vector3(_spawnThreshold, 5, 0));
	}
}
