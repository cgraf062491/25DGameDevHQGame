using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
	[SerializeField] private GameObject _display;

    void OnTriggerStay(Collider other)
    {
    	if(other.CompareTag("MovableBox"))
    	{
    		if(other.transform.position.x > 0.1f && other.transform.position.x < 0.3f)
    		{
    			Rigidbody boxbody = other.GetComponent<BoxCollider>().attachedRigidbody;
    			Renderer displayRen = _display.GetComponent<Renderer>();
	    		if(boxbody != null)
	    		{
	    			boxbody.isKinematic = true;
	    		}
	    		if(displayRen != null)
	    		{
	    			displayRen.material.SetColor("_Color", Color.blue);
	    		}
	    		Destroy(this);
    		}
    	}
    }
}
