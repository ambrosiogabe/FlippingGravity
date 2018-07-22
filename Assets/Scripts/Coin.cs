using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    Animator animator;
    ScoreKeeper scoreKeeper;
    bool addedCoin = false;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        scoreKeeper = GameObject.Find("Player").GetComponent<ScoreKeeper>();
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            if (!addedCoin)
            {
                scoreKeeper.AddCoin();
                addedCoin = true;
            }
            animator.SetTrigger("Grab");
        }
    }

    public void DestroyThis()
    {
        addedCoin = false;
        AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, new Vector3(0f, 0f, 0f));
        Destroy(this.gameObject);
    }
}
