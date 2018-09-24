using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChunk : MonoBehaviour 
{
    public enum Color 
    {
        Red,
        Blue,
        Green,
        Yellow
    }
    [SerializeField]
    private Color _chunkColor;
    public Color ChunkColor { get { return _chunkColor; }}

    [SerializeField]
    private Vector2 _size;
    public Vector2 Size { get { return _size; }}

    public Vector3 Position { get { return transform.position; }}

	private void OnDrawGizmos()
	{
        Gizmos.DrawWireCube(transform.position, new Vector3(_size.x, _size.y, 1));
	}
}
