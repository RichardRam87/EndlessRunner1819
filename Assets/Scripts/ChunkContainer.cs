using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkContainer : MonoBehaviour 
{
    private List<LevelChunk> _activeChunks = new List<LevelChunk>();
    private LevelChunk _currentChunk;
    public LevelChunk CurrentChunk { get { return _currentChunk; }}

	private void Start()
	{
        AddChunk(FindObjectOfType<LevelChunk>());
	}

	public void AddChunk(LevelChunk chunk)
    {
        _activeChunks.Add(chunk);
        _currentChunk = chunk;
    }

    public void RemoveChunk(LevelChunk chunk)
    {
        if (_activeChunks.Contains(chunk))
            _activeChunks.Remove(chunk);
    }

    public bool HasChunkColor(LevelChunk.Color chunkColor)
    {
        for (int i = 0; i < _activeChunks.Count; i++)
        {
            if (_activeChunks[i].ChunkColor == chunkColor)
                return true;
        }
        return false;
    }

    public bool HasAllColors()
    {
        bool hasRed = HasChunkColor(LevelChunk.Color.Red);
        bool hasGreen = HasChunkColor(LevelChunk.Color.Green);
        bool hasBlue = HasChunkColor(LevelChunk.Color.Blue);

        return (hasRed && hasGreen && hasBlue) == true;
    }
}
