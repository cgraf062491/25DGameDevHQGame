using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	[SerializeField] private float _speed = 5.0f;
	[SerializeField] private float _gravity = 1.0f;
	[SerializeField] private float _jumpHeight = 15.0f;
	private float _yVelocity;
	public int coins;
	private int _lives = 3;

	private bool _canDoubleJump = true;
	private bool isDamaged = false;

	private CharacterController _controller;
	private Vector3 orig_pos;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        orig_pos = transform.position;
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

        if(transform.position.y <= -5.0f && isDamaged == false)
        {
        	isDamaged = true;
        	Damage();
        }
    }

    void Damage()
    {
    	_lives -= 1;
        if(_lives == 0)
        {
        	SceneManager.LoadScene(0);
        }
        else
        {
        	transform.position = orig_pos;
        	UIManager.Instance.UpdateLivesDisplay(_lives);
        	isDamaged = false;
        }
    }
}
