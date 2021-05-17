using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreDisplay : MonoBehaviour
{
    private void Awake()
    {
        Text text = GetComponent<Text>();
        text.text = $"Highscore 1: {PlayerPrefs.GetInt("Highscore1")}\n<color=#000000>Highscore 2: </color>{PlayerPrefs.GetInt("Highscore2")}\n<color=#000000>Highscore 3: </color>{PlayerPrefs.GetInt("Highscore3")}";
    }
}
