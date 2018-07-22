using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdScript : MonoBehaviour {

    public static GameObject playRewardVideoButton;
    public static GameObject skipVideoButton;
    public static int numOfDeaths;
    private static bool isPlaying = false;
    private static LevelManager levelManager;

	// Use this for initialization
	void Start () {
        levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>();
        AdScript.playRewardVideoButton = GameObject.Find("Reward Video");
        AdScript.skipVideoButton = GameObject.Find("Continue");
        AdScript.playRewardVideoButton.SetActive(false);
        AdScript.skipVideoButton.SetActive(false);
        AdScript.numOfDeaths = PlayerPrefsManager.GetAdDeaths();

        if(Advertisement.isSupported)
            Advertisement.Initialize("1580635");
    }

    public static void ShowAd(bool died)
    {
        if (died && AdScript.numOfDeaths >= 6 || !died)
        {
            AdScript.numOfDeaths = 0;
            PlayerPrefsManager.SetAdDeaths(0);
            if (Advertisement.IsReady("video") && !AdScript.isPlaying)
            {
                var options = new ShowOptions();
                options.resultCallback = AdScript.HandleShowResult;
                Advertisement.Show("video", options);
                AdScript.isPlaying = true;
            }
            else
            {
                Debug.LogError("NOT SHOWING");
            }
        }
        else if(died && AdScript.numOfDeaths == 3 || !died)
        {
            AdScript.numOfDeaths++;
            PlayerPrefsManager.SetAdDeaths(AdScript.numOfDeaths);
            AdScript.playRewardVideoButton.SetActive(true);
            AdScript.skipVideoButton.SetActive(true);
            Time.timeScale = 0;
        }
        else if (died)
        {
            AdScript.numOfDeaths++;
            PlayerPrefsManager.SetAdDeaths(AdScript.numOfDeaths);
            Time.timeScale = 1;
            AdScript.levelManager.MenuLoadLevel(PlayerPrefsManager.GetMap());
        }
    }

    public void PlayRewardVideo()
    {
        if (Advertisement.IsReady("rewardedVideo") && !AdScript.isPlaying)
        {
            var options = new ShowOptions();
            options.resultCallback = AdScript.HandleShowResultWithReward;
            Advertisement.Show("rewardedVideo", options);
            AdScript.isPlaying = true;
        }
    }

    public void SkipRewardVideo()
    {
        Time.timeScale = 1;
        playRewardVideoButton.SetActive(false);
        skipVideoButton.SetActive(false);
        levelManager.MenuLoadLevel(PlayerPrefsManager.GetMap());
    }

    public static void HandleShowResult(ShowResult result)
    {
        Time.timeScale = 1;
        AdScript.isPlaying = false;
        string curMap = PlayerPrefsManager.GetMap();
        AdScript.levelManager.MenuLoadLevel(curMap);
    }

    public static void HandleShowResultWithReward(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            int coins = PlayerPrefsManager.GetNumOfCoins();
            coins += 5;
            PlayerPrefsManager.SetNumOfCoins(coins);
        }
        else if (result == ShowResult.Failed)
        {
            Debug.LogError("Video failed to show");
        }

        Time.timeScale = 1;
        AdScript.isPlaying = false;
        AdScript.levelManager.MenuLoadLevel(PlayerPrefsManager.GetMap());
    }
}
