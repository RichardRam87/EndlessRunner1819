using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    [SerializeField]
    private float _speed;

    private Rigidbody2D _rb2d;

	private void Start()
	{
        _rb2d = GetComponent<Rigidbody2D>();
	}
	private void Update()
	{
        var velocity = Vector2.right * _speed;
        _rb2d.MovePosition(_rb2d.position + velocity * Time.deltaTime);
	}
}
