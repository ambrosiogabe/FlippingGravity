using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Animator animator;
    bool onGround = false;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.localRotation = Quaternion.identity;

	    if( (Input.GetKeyDown(KeyCode.UpArrow) && onGround) || (SwipeScript.GetTouch() == 0 && onGround) )
        {
            GetComponent<ConstantForce2D>().force = new Vector3(0f, 30f, 0f);
            //animator.SetTrigger("Flip");
            this.transform.localScale = new Vector3(0.9764434f, -0.9764434f, 0.9764434f);
            onGround = false;
            GetComponent<AudioSource>().Play();
        }	

        if( (Input.GetKeyDown(KeyCode.DownArrow) && onGround) || (SwipeScript.GetTouch() == 1 && onGround) )
        {
            GetComponent<ConstantForce2D>().force = new Vector3(0f, -30f, 0f);
            this.transform.localScale = new Vector3(0.9764434f, 0.9764434f, 0.9764434f);
            onGround = false;
            GetComponent<AudioSource>().Play();
        }

        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<ConstantForce2D>().force = new Vector3(0f, -1 * GetComponent<ConstantForce2D>().force.y, 0f);
            this.transform.localScale = new Vector3(this.transform.localScale.x, -1 * transform.localScale.y, transform.localScale.z);
            onGround = false;
            GetComponent<AudioSource>().Play();
        }

        if(this.transform.position.x < 0)
        {
            Lose.LoseGame();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Ground>())
        {
            onGround = true;
        }
    }
}
