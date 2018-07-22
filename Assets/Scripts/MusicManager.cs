using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip[] sounds;
    private AudioClip currentSound;
    private AudioSource sound;

    private string soundPlaying;

    private void Awake()
    {
        if(GameObject.Find("MusicManager") != this.gameObject)
        {
            Destroy(this.gameObject);
            Debug.Log("Destroying duplicate music manager.");
        }
        DontDestroyOnLoad(this.gameObject);
        sound = GetComponent<AudioSource>();
    }

    public void StartMusic()
    {
        if (PlayerPrefsManager.GetMap() == "01 Start_Robot")
        {
            if (soundPlaying != "Robot")
            {
                if (sound.isPlaying)
                    sound.Stop();

                soundPlaying = "Robot";
                currentSound = sounds[0];
                sound.clip = currentSound;
                sound.Play();
            }
        }
        else if (PlayerPrefsManager.GetMap() == "01 Start_Winter")
        {
            if (soundPlaying != "Winter")
            {
                if (sound.isPlaying)
                    sound.Stop();

                soundPlaying = "Winter";
                currentSound = sounds[1];
                sound.clip = currentSound;
                sound.Play();
            }
        }
        else if (PlayerPrefsManager.GetMap() == "01 Start_Zombie")
        {
            if (soundPlaying != "Zombie")
            {
                if (sound.isPlaying)
                    sound.Stop();

                soundPlaying = "Zombie";
                currentSound = sounds[2];
                sound.clip = currentSound;
                sound.Play();
            }
        }

    }
}
