using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	private static UIManager _instance;
	public static UIManager Instance
	{
		get
		{
			if(_instance == null)
			{
				Debug.LogError("UIManager is null!");
			}

			return _instance;
		}
	}

	[SerializeField] private Text _coinDisplay = null;
	[SerializeField] private Text _livesDisplay = null;
    // Start is called before the first frame update
    void Awake()
    {
        _instance = this;
        _coinDisplay.text = "Coins: 0";
        _livesDisplay.text = "Lives: 3";
    }

    public void UpdateCoinDisplay(int coinAmount)
    {
        _coinDisplay.text = "Coins: " + coinAmount;
    }

    public void UpdateLivesDisplay(int livesAmount)
    {
        _livesDisplay.text = "Lives: " + livesAmount;
    }
}
