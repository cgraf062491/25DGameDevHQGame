using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
	private GameObject _callButton;
	private bool _elevatorCalled = false;
	[SerializeField] private Elevator _elevator = null;
	[SerializeField] private int _requiredCoins = 8;

	void Awake()
	{
		_callButton = transform.GetChild(0).gameObject;
	}

    void OnTriggerStay(Collider other)
    {
    	if(other.CompareTag("Player"))
    	{
    		if(Input.GetKeyDown(KeyCode.E) && other.GetComponent<Player>().CheckCoins() >= _requiredCoins)
    		{
    			if(_elevatorCalled == false)
    			{
    				_callButton.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    				_elevatorCalled = true;
    			}
    			else
    			{
    				_callButton.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    				_elevatorCalled = false;
    			}
    			
    			_elevator.CallElevator();
    		}
    	}
    }
}
