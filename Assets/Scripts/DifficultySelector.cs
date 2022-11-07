using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySelector : MonoBehaviour
{
    public SceneFader fader;

    public Button leftButton;
    public Button rightButton;

    public TextMeshProUGUI difficulty;
    public TextMeshProUGUI difficultySubtitle;
    public TextMeshProUGUI difficultyDescription;

    public string[] difficultyList = new string[3]{ "Easy", "Medium", "Hard" };
    private int difficultyIndex = 0;
    
    public void DifficultyLeft()
    {
        if (difficultyIndex == 0)
        {
            leftButton.interactable = false;
            return;
        }
        else
        {
            rightButton.interactable = true;
            difficultyIndex--;
            difficulty.text = difficultyList[difficultyIndex];
        }
    }

    public void DifficultyRight()
    {
        if (difficultyIndex == difficultyList.Length-1)
        {
            rightButton.interactable = false;
            return;
        }
        else
        {
            leftButton.interactable = true;
            difficultyIndex++;
            difficulty.text = difficultyList[difficultyIndex];
        }
    }

    public void Continue()
    {
        PlayerPrefs.SetInt("Difficulty", difficultyIndex);
        fader.FadeTo("LevelSelect");
    }
}
