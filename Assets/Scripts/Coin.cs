using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
    	if(other.CompareTag("Player"))
    	{
    		int newCoins = other.gameObject.GetComponent<Player>().coins += 1;
    		Destroy(this.gameObject);
    		UIManager.Instance.UpdateCoinDisplay(newCoins);
    	}
    }
}
