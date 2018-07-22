using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterShop : MonoBehaviour {

    public GameObject selectedCharacter;
    private Text coinsText, coinsShadow;
    private LevelManager levelManager;

    // Use this for initialization
    void Start() {
        //PlayerPrefsManager.SetNumOfCoins(50);
        selectedCharacter = GameObject.Find(PlayerPrefsManager.GetPlayer());
        PlayerPrefsManager.BuyCharacter("Robot");

        coinsText = GameObject.Find("Coins").GetComponent<Text>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();

	    for(int i=0; i < transform.childCount; i++)
        {
            GameObject button = transform.GetChild(i).gameObject;

            /* PlayerPrefsManager.LockCharacter(button.name); //Uncomment to lock all characters!!! */

            if (PlayerPrefsManager.IsCharacterBought(button.name))
            {
                button.GetComponent<Button>().interactable = true;
            } else
            {
                button.GetComponent<Button>().interactable = false;
            }

            if(PlayerPrefsManager.GetPlayer() == button.name)
            {
                button.GetComponent<Button>().Select();
            }
        }
        UpdateScreen(selectedCharacter);
	}

    public void UpdateScreen(GameObject clickedCharacter)
    {
        Debug.Log(clickedCharacter.name);
        int coins = PlayerPrefsManager.GetNumOfCoins();
        coinsText.text = "Coins: " + coins;

        selectedCharacter = clickedCharacter;
        selectedCharacter.GetComponent<Button>().interactable = true;
        selectedCharacter.GetComponent<Button>().Select();
    }

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetPlayer(selectedCharacter.name);
        levelManager.MenuLoadLevel(PlayerPrefsManager.GetMap());
    }
}
