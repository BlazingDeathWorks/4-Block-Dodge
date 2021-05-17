using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    Text text = null;

    private void Awake()
    {
        text = GetComponent<Text>();
        HighscoreManager.ScoreIncrease += OnScoreIncrease;
    }

    private void OnDisable()
    {
        HighscoreManager.ScoreIncrease -= OnScoreIncrease;
    }

    private void OnScoreIncrease(int score)
    {
        text.text = score.ToString();
    }
}
