using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkDestroyer : MonoBehaviour 
{
    private ChunkContainer _chunkContainer;

	private void Awake()
	{
        _chunkContainer = FindObjectOfType<ChunkContainer>();	
	}
	
    private void OnTriggerEnter2D(Collider2D collision)
	{
        var chunk = collision.GetComponent<LevelChunk>();
        if (chunk != null)
        {
            _chunkContainer.RemoveChunk(chunk);
            Destroy(chunk.gameObject);
        }
	}
}
