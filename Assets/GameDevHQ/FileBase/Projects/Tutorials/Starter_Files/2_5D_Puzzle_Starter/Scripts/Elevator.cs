using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
	private bool _goingDown = false;
	private bool _goingUp = false;

	[SerializeField] private Transform _origin, _target;
	[SerializeField] private float _speed = 2.0f;

    public void CallElevator()
    {
    	if(transform.position == _origin.position)
    	{
    		_goingDown = true;
    	}
    	else if(transform.position == _target.position)
    	{
    		_goingUp = true;
    	}
    }

    void FixedUpdate()
    {
    	if(_goingDown == true)
    	{
    		transform.position = Vector3.MoveTowards(transform.position, _target.position, Time.deltaTime * _speed);
    		if(transform.position == _target.position)
    		{
    			_goingDown = false;
    		}
    	}

    	if(_goingUp == true)
    	{
    		transform.position = Vector3.MoveTowards(transform.position, _origin.position, Time.deltaTime * _speed);
    		if(transform.position == _origin.position)
    		{
    			_goingUp = false;
    		}
    	}
    }

    void OnTriggerEnter(Collider other)
    {
    	if (other.CompareTag("Player"))
        {
            other.transform.parent = this.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
    	if (other.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}
