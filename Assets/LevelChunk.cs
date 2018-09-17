using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChunk : MonoBehaviour 
{
    [SerializeField]
    private Vector2 _size;

	private void OnDrawGizmos()
	{
        Gizmos.DrawWireCube(transform.position, new Vector3(_size.x, _size.y, 1));
	}
}
