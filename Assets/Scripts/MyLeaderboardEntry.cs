using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyLeaderboardEntry : MonoBehaviour
{
    Text entryText = null;
    public int Score { get; set; } = 0;
    public int Rank { get; set; } = 1;

    private void Awake()
    {
        entryText = GetComponent<Text>();
    }

    public void InitializeEntry(string input)
    {
        entryText.text = input;//$"Rank {Rank}:\t{Score}";
    }
}
