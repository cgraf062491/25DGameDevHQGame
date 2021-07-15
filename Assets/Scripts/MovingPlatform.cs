using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
	[SerializeField] private Transform _targetA, _targetB;

	private float _speed = 3.0f;

	private bool _goingBack = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    	if(_goingBack == false)
    	{
    		transform.position = Vector3.MoveTowards(transform.position, _targetB.position, Time.deltaTime * _speed);

    		if(transform.position == _targetB.position)
    		{
    			_goingBack = true;
    		}
    	}
    	else
    	{
    		transform.position = Vector3.MoveTowards(transform.position, _targetA.position, Time.deltaTime * _speed);

    		if(transform.position == _targetA.position)
    		{
    			_goingBack = false;
    		}
    	}
    }

    void OnTriggerEnter(Collider other)
    {
    	if(other.CompareTag("Player"))
    	{
    		other.transform.parent = this.transform;
    	}
    }

    void OnTriggerExit(Collider other)
    {
    	if(other.CompareTag("Player"))
    	{
    		other.transform.parent = null;
    	}
    }
}
