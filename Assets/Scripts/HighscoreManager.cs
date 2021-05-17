using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HighscoreManager : IPlayerCollisionHandler
{
    [SerializeField]
    MyLeaderboardEntry entryObject = null;
    [SerializeField]
    float speedIncreaseRate = 5;
    private float timeSinceLastSpeedIncrease = 0;

    public static event Action<int> ScoreIncrease;
    private float timeSinceLastScoreIncrease = 0;
    private int score = 0;

    // Update is called once per frame
    void Update()
    {
        IncreaseBlockSpeed();
        IncreaseScore();
    }

    private void IncreaseBlockSpeed()
    {
        if (timeSinceLastSpeedIncrease >= speedIncreaseRate)
        {
            timeSinceLastSpeedIncrease = 0;
            BlockMovement.moveSpeed++;
            return;
        }
        timeSinceLastSpeedIncrease += Time.deltaTime;
    }
    
    private void IncreaseScore()
    {
        if(timeSinceLastScoreIncrease >= speedIncreaseRate / 2)
        {
            timeSinceLastScoreIncrease = 0;
            score++;
            ScoreIncrease?.Invoke(score);
            return;
        }
        timeSinceLastScoreIncrease += Time.deltaTime;
    }

    public override void OnPlayerCollision()
    {
        /*if(Leaderboard.instance.LeaderboardEntries.Count <= 3)
        {
            Leaderboard.instance.CreateEntry(score);
        }*/
        if (score > PlayerPrefs.GetInt("Highscore1"))
        {
            PlayerPrefs.SetInt("Highscore3", PlayerPrefs.GetInt("Highscore2"));
            Debug.Log($"Highscore 3: {PlayerPrefs.GetInt("Highscore3")}");
            PlayerPrefs.SetInt("Highscore2", PlayerPrefs.GetInt("Highscore1"));
            Debug.Log($"Highscore 2: {PlayerPrefs.GetInt("Highscore2")}");
            PlayerPrefs.SetInt("Highscore1", score);
            Debug.Log($"Highscore 1: {PlayerPrefs.GetInt("Highscore1")}");
            PlayerPrefs.Save();
            return;
        }
        if (score > PlayerPrefs.GetInt("Highscore2"))
        {
            PlayerPrefs.SetInt("Highscore3", PlayerPrefs.GetInt("Highscore2"));
            PlayerPrefs.SetInt("Highscore2", score);
            PlayerPrefs.Save();
            return;
        }
        if (score > PlayerPrefs.GetInt("Highscore3"))
        {
            PlayerPrefs.SetInt("Highscore3", score);
            PlayerPrefs.Save();
            return;
        }
    }

    private void Awake()
    {
        /*for(int i = 0; i < 3; i++)
        {
            PlayerPrefs.SetInt($"Highscore{i + 1}", 0);
        }*/
    }
}
