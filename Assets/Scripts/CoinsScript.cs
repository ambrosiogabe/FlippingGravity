using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsScript : MonoBehaviour {

    public Text shadowText;

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = "Coins: " + PlayerPrefsManager.GetNumOfCoins();
        shadowText.text = GetComponent<Text>().text;
	}
}
