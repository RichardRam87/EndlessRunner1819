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

	private void Awake()
	{
        _player = GameObject.FindWithTag("Player").transform;
	}

	private void Update()
	{
        if (_spawnThreshold > _player.position.x) return;

        SpawnChunk();
 	}

    void SpawnChunk()
    {
        print("Spawn");
    }

	private void OnDrawGizmos()
	{
        Gizmos.DrawLine(new Vector3(_spawnThreshold, -5, 0), new Vector3(_spawnThreshold, 5, 0));
	}
}
