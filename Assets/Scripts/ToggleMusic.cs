using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefsManager.SetSound("01 Start_Robot", 0.5f);
        PlayerPrefsManager.SetSound("01 Start_Winter", 0.5f);
        PlayerPrefsManager.SetSound("01 Start_Zombie", 0.5f);
        PlayerPrefsManager.SetSound("01 Start_Desert", 0.5f);

        if (PlayerPrefsManager.GetSound(PlayerPrefsManager.GetMap()))
        {
            this.GetComponent<Button>().interactable = true;
            GameObject.Find("MusicManager").GetComponent<AudioSource>().volume = 0.5f;
        } else
        {
            this.GetComponent<Button>().interactable = false;
            GameObject.Find("MusicManager").GetComponent<AudioSource>().volume = 0f;
        }
	}
	
    void OnMouseDown()
    {
        if(PlayerPrefsManager.GetSound(PlayerPrefsManager.GetMap()))
        {
            this.GetComponent<Button>().interactable = false;
            PlayerPrefsManager.SetSound(PlayerPrefsManager.GetMap(), 0f);
            GameObject.Find("MusicManager").GetComponent<AudioSource>().volume = 0f;
        } else
        {
            this.GetComponent<Button>().interactable = true;
            PlayerPrefsManager.SetSound(PlayerPrefsManager.GetMap(), 0.5f);
            GameObject.Find("MusicManager").GetComponent<AudioSource>().volume = 0.5f;
        }
    }
}
