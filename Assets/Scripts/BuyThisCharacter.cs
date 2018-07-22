using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyThisCharacter : MonoBehaviour {

    public int cost;
    private CharacterShop script;

	// Use this for initialization
	void Start () {
        script = GameObject.Find("Buttons").GetComponent<CharacterShop>();
	}

    private void OnMouseDown()
    {
        if(PlayerPrefsManager.GetNumOfCoins() >= this.cost && !PlayerPrefsManager.IsCharacterBought(this.gameObject.name))
        {
             PlayerPrefsManager.SetNumOfCoins(PlayerPrefsManager.GetNumOfCoins() - cost);
             PlayerPrefsManager.BuyCharacter(this.gameObject.name);
             script.UpdateScreen(this.gameObject);
        }
        else if (PlayerPrefsManager.IsCharacterBought(this.gameObject.name))
        {
            script.selectedCharacter = this.gameObject;
            script.UpdateScreen(this.gameObject);
        }
    }
}
