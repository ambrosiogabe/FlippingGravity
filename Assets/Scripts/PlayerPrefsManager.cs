using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

    private const string SCORE = "Default_Score";
    private const string COINS = "Coins";
    private const string MAP = "Map";
    private const string PLAYER = "Current_Player";
    private const string CURRENT_CHARACTER = "Current_Character";
    private const string SCORE_WINTER = "Winter_Score";
    private const string SCORE_ZOMBIE = "Zombie_Score";
    private const string SCORE_DESERT = "Desert_Score";

    private const string DEFAULT_SOUND = "Default_Sound";
    private const string WINTER_SOUND = "Winter_Sound";
    private const string ZOMBIE_SOUND = "Zombie_Sound";
    private const string DESERT_SOUND = "Desert_Sound";

    private const string BOUGHT_DEFAULT = "Default_Bought";
    private const string BOUGHT_WINTER = "Winter_Bought";
    private const string BOUGHT_ZOMBIE = "Zombie_Bought";
    private const string BOUGHT_DESERT = "Desert_Bought";

    private const string BOUGHT_MALE_ZOMBIE = "Bought_Male_Zombie";
    private const string BOUGHT_FEMALE_ZOMBIE = "Bought_Female_Zombie";
    private const string BOUGHT_ROBOT = "Bought_Robot";
    private const string BOUGHT_SANTA = "Bought_Santa";
    private const string BOUGHT_TEMPLE_GIRL = "Bought_Temple_Girl";
    private const string BOUGHT_TEMPLE_BOY = "Bought_Temple_Boy";
    private const string BOUGHT_CAT = "Bought_Cat";
    private const string BOUGHT_DOG = "Bought_Dog";
    private const string BOUGHT_CUTE_GIRL = "Bought_Cute_Girl";
    private const string BOUGHT_NINJA_BOY = "Bought_Ninja_Boy";
    private const string BOUGHT_NINJA_GIRL = "Bought_Ninja_Girl";
    private const string BOUGHT_ELF_ONE = "Bought_Elf_One";
    private const string BOUGHT_ELF_TWO = "Bough_Elf_Two";
    private const string BOUGHT_ELF_THREE = "Bought_Elf_Three";
    private const string BOUGHT_KNIGHT = "Bought_Knight";
    private const string BOUGHT_JACK = "Bought_Jack";

    private const string AD_DEATHS = "Ad_Deaths";

    public static void SetNumOfCoins(int coins)
    {
        PlayerPrefs.SetInt(COINS, coins);
    }

    public static void SetScore(int score)
    {
        if (GetMap() == "01 Start_Robot")
            PlayerPrefs.SetInt(SCORE, score);
        else if (GetMap() == "01 Start_Winter")
            PlayerPrefs.SetInt(SCORE_WINTER, score);
        else if (GetMap() == "01 Start_Zombie")
            PlayerPrefs.SetInt(SCORE_ZOMBIE, score);
        else if (GetMap() == "01 Start_Desert")
            PlayerPrefs.SetInt(SCORE_DESERT, score);
    }

    public static void SetMap(string map)
    {
        PlayerPrefs.SetString(MAP, map);
    }

    public static void SetPlayer(string player)
    {
        PlayerPrefs.SetString(PLAYER, player);
    }

    public static void BuyMap(string map)
    {
        if (map == "Default Map")
            PlayerPrefs.SetInt(BOUGHT_DEFAULT, 1);
        else if (map == "Winter Map")
            PlayerPrefs.SetInt(BOUGHT_WINTER, 1);
        else if (map == "Zombie Map")
            PlayerPrefs.SetInt(BOUGHT_ZOMBIE, 1);
        else if (map == "Desert Map")
            PlayerPrefs.SetInt(BOUGHT_DESERT, 1);
    }

    public static void SetSound(string map, float value)
    {
        if (map == "01 Start_Robot")
            PlayerPrefs.SetFloat(DEFAULT_SOUND, value);
        else if (map == "01 Start_Winter")
            PlayerPrefs.SetFloat(WINTER_SOUND, value);
        else if (map == "01 Start_Zombie")
            PlayerPrefs.SetFloat(ZOMBIE_SOUND, value);
        else if (map == "01 Start_Desert")
            PlayerPrefs.SetFloat(DESERT_SOUND, value);
    }

    public static bool GetSound(string map)
    {
        if (map == "01 Start_Robot")
            return PlayerPrefs.GetFloat(DEFAULT_SOUND) == 0.5f;
        else if (map == "01 Start_Winter")
            return PlayerPrefs.GetFloat(WINTER_SOUND) == 0.5f;
        else if (map == "01 Start_Zombie")
            return PlayerPrefs.GetFloat(ZOMBIE_SOUND) == 0.5f;
        else if (map == "01 Start_Desert")
            return PlayerPrefs.GetFloat(DESERT_SOUND) == 0.5f;

        return false;

    }

    public static void SetAdDeaths(int num)
    {
        PlayerPrefs.SetInt(AD_DEATHS, num);
    }

    public static void BuyCharacter(string character)
    {
        if (character == "Robot")
            PlayerPrefs.SetInt(BOUGHT_ROBOT, 1);
        else if (character == "Santa")
            PlayerPrefs.SetInt(BOUGHT_SANTA, 1);
        else if (character == "Male_Zombie")
            PlayerPrefs.SetInt(BOUGHT_MALE_ZOMBIE, 1);
        else if (character == "Female_Zombie")
            PlayerPrefs.SetInt(BOUGHT_FEMALE_ZOMBIE, 1);
        else if (character == "Temple_Boy")
            PlayerPrefs.SetInt(BOUGHT_TEMPLE_BOY, 1);
        else if (character == "Temple_Girl")
            PlayerPrefs.SetInt(BOUGHT_TEMPLE_GIRL, 1);
        else if (character == "Cat")
            PlayerPrefs.SetInt(BOUGHT_CAT, 1);
        else if (character == "Dog")
            PlayerPrefs.SetInt(BOUGHT_DOG, 1);
        else if (character == "Cute_Girl")
            PlayerPrefs.SetInt(BOUGHT_CUTE_GIRL, 1);
        else if (character == "Ninja_Boy")
            PlayerPrefs.SetInt(BOUGHT_NINJA_BOY, 1);
        else if (character == "Ninja_Girl")
            PlayerPrefs.SetInt(BOUGHT_NINJA_GIRL, 1);
        else if (character == "Elf_1")
            PlayerPrefs.SetInt(BOUGHT_ELF_ONE, 1);
        else if (character == "Elf_2")
            PlayerPrefs.SetInt(BOUGHT_ELF_TWO, 1);
        else if (character == "Knight")
            PlayerPrefs.SetInt(BOUGHT_KNIGHT, 1);
        else if (character == "Elf_3")
            PlayerPrefs.SetInt(BOUGHT_ELF_THREE, 1);
        else if (character == "Jack")
            PlayerPrefs.SetInt(BOUGHT_JACK, 1);
    }

    public static void LockCharacter(string character)
    {
        if (character == "Robot")
            PlayerPrefs.SetInt(BOUGHT_ROBOT, 0);
        else if (character == "Santa")
            PlayerPrefs.SetInt(BOUGHT_SANTA, 0);
        else if (character == "Male_Zombie")
            PlayerPrefs.SetInt(BOUGHT_MALE_ZOMBIE, 0);
        else if (character == "Female_Zombie")
            PlayerPrefs.SetInt(BOUGHT_FEMALE_ZOMBIE, 0);
        else if (character == "Temple_Boy")
            PlayerPrefs.SetInt(BOUGHT_TEMPLE_BOY, 0);
        else if (character == "Temple_Girl")
            PlayerPrefs.SetInt(BOUGHT_TEMPLE_GIRL, 0);
        else if (character == "Cat")
            PlayerPrefs.SetInt(BOUGHT_CAT, 0);
        else if (character == "Dog")
            PlayerPrefs.SetInt(BOUGHT_DOG, 0);
        else if (character == "Cute_Girl")
            PlayerPrefs.SetInt(BOUGHT_CUTE_GIRL, 0);
        else if (character == "Ninja_Boy")
            PlayerPrefs.SetInt(BOUGHT_NINJA_BOY, 0);
        else if (character == "Ninja_Girl")
            PlayerPrefs.SetInt(BOUGHT_NINJA_GIRL, 0);
        else if (character == "Elf_1")
            PlayerPrefs.SetInt(BOUGHT_ELF_ONE, 0);
        else if (character == "Elf_2")
            PlayerPrefs.SetInt(BOUGHT_ELF_TWO, 0);
        else if (character == "Elf_3")
            PlayerPrefs.SetInt(BOUGHT_ELF_THREE, 0);
        else if (character == "Knight")
            PlayerPrefs.SetInt(BOUGHT_KNIGHT, 0);
        else if (character == "Jack")
            PlayerPrefs.SetInt(BOUGHT_JACK, 0);
    }

    public static void LockMap(string map)
    {
        if (map == "Default Map")
            PlayerPrefs.SetInt(BOUGHT_DEFAULT, 0);
        else if (map == "Winter Map")
            PlayerPrefs.SetInt(BOUGHT_WINTER, 0);
        else if (map == "Zombie Map")
            PlayerPrefs.SetInt(BOUGHT_ZOMBIE, 0);
        else if (map == "Desert Map")
            PlayerPrefs.SetInt(BOUGHT_DESERT, 0);
    }

    public static string GetPlayer()
    {
        if(PlayerPrefs.GetString(PLAYER) != null || PlayerPrefs.GetString(PLAYER) != "")
            return PlayerPrefs.GetString(PLAYER);
        return "Robot";
    }

    public static string GetMap()
    {
        if(PlayerPrefs.GetString(MAP) == null)
            return "01 Start_Robot";
        return PlayerPrefs.GetString(MAP);
    }

    public static int GetNumOfCoins()
    {
        if(PlayerPrefs.GetInt(COINS) == null)
            return 0;
        return PlayerPrefs.GetInt(COINS);
    }

    public static int GetScore()
    {
        if (GetMap() == "01 Start_Robot" && PlayerPrefs.GetInt(SCORE) != null)
            return PlayerPrefs.GetInt(SCORE);
        else if (GetMap() == "01 Start_Winter" && PlayerPrefs.GetInt(SCORE_WINTER) != null)
            return PlayerPrefs.GetInt(SCORE_WINTER);
        else if (GetMap() == "01 Start_Zombie" && PlayerPrefs.GetInt(SCORE_ZOMBIE) != null)
            return PlayerPrefs.GetInt(SCORE_ZOMBIE);
        else if (GetMap() == "01 Start_Desert" && PlayerPrefs.GetInt(SCORE_DESERT) != null)
            return PlayerPrefs.GetInt(SCORE_DESERT);

        return 0;
    }

    public static bool IsMapBought(string map)
    {
        int num = -1;
        if (map == "Default Map")
            num = PlayerPrefs.GetInt(BOUGHT_DEFAULT);
        else if (map == "Winter Map")
            num = PlayerPrefs.GetInt(BOUGHT_WINTER);
        else if (map == "Zombie Map")
            num = PlayerPrefs.GetInt(BOUGHT_ZOMBIE);
        else if (map == "Desert Map")
            num = PlayerPrefs.GetInt(BOUGHT_DESERT);

        if (num == 0)
            return false;
        else if (num == 1)
            return true;

        return false;
    }

    public static bool IsCharacterBought(string character)
    {
        if (character == "Robot")
            return PlayerPrefs.GetInt(BOUGHT_ROBOT) == 1;
        else if (character == "Santa")
            return PlayerPrefs.GetInt(BOUGHT_SANTA) == 1;
        else if (character == "Male_Zombie")
            return PlayerPrefs.GetInt(BOUGHT_MALE_ZOMBIE) == 1;
        else if (character == "Female_Zombie")
            return PlayerPrefs.GetInt(BOUGHT_FEMALE_ZOMBIE) == 1;
        else if (character == "Temple_Boy")
            return PlayerPrefs.GetInt(BOUGHT_TEMPLE_BOY) == 1;
        else if (character == "Temple_Girl")
            return PlayerPrefs.GetInt(BOUGHT_TEMPLE_GIRL) == 1;
        else if (character == "Cat")
            return PlayerPrefs.GetInt(BOUGHT_CAT) == 1;
        else if (character == "Dog")
            return PlayerPrefs.GetInt(BOUGHT_DOG) == 1;
        else if (character == "Cute_Girl")
            return PlayerPrefs.GetInt(BOUGHT_CUTE_GIRL) == 1;
        else if (character == "Ninja_Boy")
            return PlayerPrefs.GetInt(BOUGHT_NINJA_BOY) == 1;
        else if (character == "Ninja_Girl")
            return PlayerPrefs.GetInt(BOUGHT_NINJA_GIRL) == 1;
        else if (character == "Elf_1")
            return PlayerPrefs.GetInt(BOUGHT_ELF_ONE) == 1;
        else if (character == "Elf_2")
            return PlayerPrefs.GetInt(BOUGHT_ELF_TWO) == 1;
        else if (character == "Elf_3")
            return PlayerPrefs.GetInt(BOUGHT_ELF_THREE) == 1;
        else if (character == "Knight")
            return PlayerPrefs.GetInt(BOUGHT_KNIGHT) == 1;
        else if (character == "Jack")
            return PlayerPrefs.GetInt(BOUGHT_JACK) == 1;

        return false;
    }

    public static string GetCurrentCharacter()
    {
        if(PlayerPrefs.GetString(CURRENT_CHARACTER) == "" || PlayerPrefs.GetString(CURRENT_CHARACTER) == null)
            return "Robot";
        return PlayerPrefs.GetString(CURRENT_CHARACTER);
    }

    public static int GetAdDeaths()
    {
        if(PlayerPrefs.GetInt(AD_DEATHS) != null)
            return PlayerPrefs.GetInt(AD_DEATHS);
        return 0;
    }
}
