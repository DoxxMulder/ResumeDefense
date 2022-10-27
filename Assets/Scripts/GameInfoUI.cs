using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameInfoUI : MonoBehaviour
{
    public TextMeshProUGUI killText;
    
    void Update()
    {
        killText.text = PlayerStats.TotalKills.ToString();
    }
}
