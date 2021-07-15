using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	

	[SerializeField] private float _speed = 5.0f;
	[SerializeField] private float _gravity = 1.0f;
	[SerializeField] private float _jumpHeight = 15.0f;
	private float _yVelocity;
	public int coins;

	private bool _canDoubleJump = true;

	private CharacterController _controller;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x_move = Input.GetAxisRaw("Horizontal");
        Vector3 direction = new Vector3(x_move, 0, 0);
        Vector3 velocity = direction * _speed;

        if(_controller.isGrounded == true)
        {
        	if(Input.GetKeyDown(KeyCode.Space))
        	{
        		_yVelocity += _jumpHeight;
        		_canDoubleJump = true;
        	}
        }
        else
        {
        	if(_canDoubleJump == true && Input.GetKeyDown(KeyCode.Space))
        	{
        		_yVelocity += _jumpHeight;
        		_canDoubleJump = false;
        	}
        	else
        	{
        		_yVelocity -= _gravity;
        	}
        }

        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }
}
