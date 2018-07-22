using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMaps : MonoBehaviour {

    public GameObject[] maps = new GameObject[2];
    private int currentIndex;
    private int cost = 100;

	// Use this for initialization
	void Start () {
        currentIndex = 0;
        /*
        foreach (GameObject map in maps)
        {
            PlayerPrefsManager.LockMap(map.name);
        }
        */
        PlayerPrefsManager.BuyMap(maps[0].name);

        foreach(GameObject map in maps)
        {
            if(PlayerPrefsManager.IsMapBought(map.name))
            {
                map.GetComponent<Button>().interactable = true;
            }
            else
            {
                map.GetComponent<Button>().interactable = false;
            }
        }
	}
	
    public void ToggleRight()
    {
        maps[currentIndex].gameObject.SetActive(false);
        currentIndex++;

        if (currentIndex > maps.Length - 1)
            currentIndex = 0;
        maps[currentIndex].gameObject.SetActive(true);
    }

    public void ToggleLeft()
    {
        maps[currentIndex].gameObject.SetActive(false);
        currentIndex--;

        if (currentIndex < 0)
            currentIndex = maps.Length - 1;
        maps[currentIndex].gameObject.SetActive(true);
    }

    public void BuyMap()
    {
        if(PlayerPrefsManager.GetNumOfCoins() >= cost)
        {
            maps[currentIndex].GetComponent<Button>().interactable = true;
            PlayerPrefsManager.BuyMap(maps[currentIndex].name);
            int coins = PlayerPrefsManager.GetNumOfCoins();
            coins -= 100;
            PlayerPrefsManager.SetNumOfCoins(coins);
        }
    }
}
