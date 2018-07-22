using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour {
    private static ScoreKeeper scoreKeeper;

    private void Start()
    {
        scoreKeeper = GameObject.Find("Player").GetComponent<ScoreKeeper>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>())
        {
            Lose.LoseGame();
        }
    }

    public static void LoseGame()
    {
        if (scoreKeeper.score > PlayerPrefsManager.GetScore())
            PlayerPrefsManager.SetScore(scoreKeeper.score);

        PlayerPrefsManager.SetNumOfCoins(scoreKeeper.GetCoins());
        AdScript.ShowAd(true);
    }
}
