using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScore : MonoBehaviour {

    public Text scoreText;
    public Text coinsText;

	// Use this for initialization
	void Start () {
        scoreText.text = "Highscore: " + PlayerPrefsManager.GetScore();
        coinsText.text = "Coins: " + PlayerPrefsManager.GetNumOfCoins();
	}
}
