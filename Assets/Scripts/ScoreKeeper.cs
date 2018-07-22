using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
    private Text scoreText, scoreShadow, coinsText, coinsShadow;

    public  int score = 0;
    private int coins = 0;

    private IEnumerator coroutine;

	// Use this for initialization
	void Start () {
        scoreText = GameObject.Find("Score Text").GetComponent<Text>();
        coinsText = GameObject.Find("Coins Text").GetComponent<Text>();
        coinsShadow = GameObject.Find("Coins Shadow").GetComponent<Text>();
        scoreShadow = GameObject.Find("Score Shadow").GetComponent<Text>();

        score = 0;
        scoreText.text = "Score: 0";
        scoreShadow.text = scoreText.text;
        StartCoroutine(UpdateScore());

        coins = PlayerPrefsManager.GetNumOfCoins();
        coinsText.text = "Coins: " + coins;
        coinsShadow.text = coinsText.text;
	}

    IEnumerator UpdateScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            score++;
            scoreText.text = "Score: " + score;
            scoreShadow.text = scoreText.text;
        }
    }

    public void AddCoin()
    {
        coins++;
        coinsText.text = "Coins: " + coins;
        coinsShadow.text = coinsText.text;
    }

    public int GetCoins()
    {
        return coins;
    }
}
