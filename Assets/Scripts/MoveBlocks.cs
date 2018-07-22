using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlocks : MonoBehaviour {

    public float moveSpeed = 4.73f;
    public GameObject[] segments;
    public GameObject firstSegment;
    public GameObject[] characters;

    private GameObject[] objectSegments = new GameObject[3];
    private int index;
    private GameObject player;
    private ScoreKeeper scoreKeeper;
    private bool speedIncreased = false;

    private void Start()
    {

        /*  ------------------------
         * Select Appropriate player
         * ------------------------- */

        foreach (GameObject character in characters)
        {
            if (character.gameObject.name == PlayerPrefsManager.GetPlayer())
            {
                player = Instantiate(character, character.transform.position, Quaternion.identity) as GameObject;
                player.gameObject.name = "Player";
                break;
            }
        }

        GameObject veryFirst = Instantiate(firstSegment, this.transform) as GameObject;
        veryFirst.transform.position = new Vector3(0f, -0.25f, 0f);

        int startSegmentNumber = Random.RandomRange(0, segments.Length);
        int secondSegmentNumber = Random.RandomRange(0, segments.Length);
        objectSegments[0] = Instantiate(segments[startSegmentNumber], this.transform) as GameObject;
        objectSegments[0].transform.position = new Vector3(12f, -0.25f, 0f);

        objectSegments[1] = Instantiate(segments[secondSegmentNumber], this.transform) as GameObject;
        objectSegments[1].transform.position = new Vector3(24f, -0.25f, 0f);

        int thirdSegmentNumber = Random.RandomRange(0, segments.Length);
        objectSegments[2] = Instantiate(segments[thirdSegmentNumber], this.transform) as GameObject;
        objectSegments[2].transform.position = new Vector3(36f, -0.25f, 0f);

        scoreKeeper = player.GetComponent<ScoreKeeper>();
    }

    // Update is called once per frame
    void Update () {
        this.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        for (int i= 0; i < objectSegments.Length; i++) 
        {
            GameObject curSegment = objectSegments[i];
            if(curSegment.transform.childCount <= 0)
            {
                Destroy(curSegment.gameObject);
                index = i;
                CreateNewSegment(index);
                break;
            }
        }

        if(scoreKeeper.score % 10 == 0 && !speedIncreased && scoreKeeper.score != 0)
        {
            moveSpeed += 0.3f;
            speedIncreased = true;
        } else if (scoreKeeper.score % 11 == 0 && scoreKeeper.score % 10 != 0)
        {
            speedIncreased = false;
        }
	}

    void CreateNewSegment(int jIndex)
    {
        int num = Random.RandomRange(0, segments.Length);
        if(num > segments.Length - 1)
        {
            Debug.LogError("This block does not exist.");
        }

        GameObject newSegment = Instantiate(segments[num], this.transform);
        GameObject lastSegment;
        if(jIndex == 0)
        {
            lastSegment = objectSegments[2];
        }
        else
        {
            lastSegment = objectSegments[jIndex - 1];
        }

        if(PlayerPrefsManager.GetMap() == "01 Start_Robot")
            newSegment.transform.position = new Vector3( (lastSegment.transform.position.x + lastSegment.GetComponent<Collider2D>().bounds.size.x) - 0.5f, -0.25f, 0f);
        else
            newSegment.transform.position = new Vector3((lastSegment.transform.position.x + lastSegment.GetComponent<Collider2D>().bounds.size.x), - 0.2f, 0f);
        objectSegments[index] = newSegment;
    }
}
