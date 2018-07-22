using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    void OnEnable()
        {
            //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
            SceneManager.sceneLoaded += OnLevelFinishedLoading;
        }

    void OnDisable()
        {
            //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
            SceneManager.sceneLoaded -= OnLevelFinishedLoading;
        }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
        {
            if (Application.loadedLevelName == "01 Start_Robot")
            {
                PlayerPrefsManager.SetMap("01 Start_Robot");
            }
            else if (Application.loadedLevelName == "01 Start_Winter")
            {
                PlayerPrefsManager.SetMap("01 Start_Winter");
            }
            else if(Application.loadedLevelName == "01 Start_Zombie")
            {
                 PlayerPrefsManager.SetMap("01 Start_Zombie");
            }
            else if(Application.loadedLevelName == "01 Start_Desert")
            {
                PlayerPrefsManager.SetMap("01 Start_Desert");
            }
            GameObject.Find("MusicManager").GetComponent<MusicManager>().StartMusic();
        }

    public static void LoadLevel(string name)
        {
            Application.LoadLevel(name);
        }

    public static void LoadLevel()
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }

    public void MenuLoadLevel()
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }

    public void MenuLoadLevel(string levelName)
        {
            Application.LoadLevel(levelName);
        }
    public void Quit()
    {
        Application.Quit();
    }

    public void OpenLink(string link)
    {
        Application.OpenURL(link);
    }
}
