using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTitleScreenCharacters : MonoBehaviour {

    public float startPosition, endPosition;
    private float speed = 4f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Vector3.right * Time.deltaTime * speed);
        if(transform.position.x >= endPosition)
        {
            this.transform.position = new Vector3(startPosition, transform.position.y, transform.position.z);
        }
	}
}
