using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    public SceneFader sceneFader;

    public string mainMenuName = "MainMenu";
    public string nextlevel = "Level02";
    public int levelToUnlock = 2;

    public void Continue()
    {
        //sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextlevel);
    }

    public void Menu()
    {
        sceneFader.FadeTo(mainMenuName);
    }
}
