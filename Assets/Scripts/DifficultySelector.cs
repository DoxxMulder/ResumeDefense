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
    [Header("Difficulty Info")]
    public string[] difficultyList = new string[3]{ "Easy", "Medium", "Hard" };
    public string[] difficultySubtitles = new string[] { };
    public string[] difficultyDescriptions = new string[] { };
    private int difficultyIndex = 0;

    public void Start()
    {
        UpdateDifficulty();
    }

    public void Update()
    {
        if (difficultyIndex == 0)
        {
            leftButton.interactable = false;
        }
        else
        {
            leftButton.interactable = true;
        }
        if (difficultyIndex == difficultyList.Length - 1)
        {
            rightButton.interactable = false;
        }
        else
        {
            rightButton.interactable = true;
        }

    }

    public void DifficultyLeft()
    {
        if (difficultyIndex == 0)
        {
            return;
        }
        else
        {
            difficultyIndex--;
            UpdateDifficulty();
        }        
    }

    public void DifficultyRight()
    {
        if (difficultyIndex == difficultyList.Length-1)
        {
            return;
        }
        else
        {
            difficultyIndex++;
            UpdateDifficulty();
        }
    }

    public void Continue()
    {
        PlayerPrefs.SetInt("Difficulty", difficultyIndex);
        fader.FadeTo("LevelSelect");
    }
    private void UpdateDifficulty()
    {
        difficulty.text = difficultyList[difficultyIndex];
        difficultySubtitle.text = difficultySubtitles[difficultyIndex];
        difficultyDescription.text = difficultyDescriptions[difficultyIndex];
    }

}
