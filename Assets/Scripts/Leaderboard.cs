using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Leaderboard : IPlayerCollisionHandler
{
    public static Leaderboard instance = null;
    [SerializeField]
    MyLeaderboardEntry entryObject = null;
    [SerializeField]
    float height = 300;
    public List<MyLeaderboardEntry> LeaderboardEntries { get; private set; } = new List<MyLeaderboardEntry>();
    [SerializeField]
    private RectTransform referenceAnchor = null;
    [SerializeField]
    private RectTransform visuals = null;
    private int times = 0;
    List<int> scoreList = new List<int>();
    Stack<int> scoreStack = new Stack<int>();

    public void CreateEntry(int score)
    {
        MyLeaderboardEntry entry = Instantiate(entryObject, transform.position, Quaternion.identity);
        DontDestroyOnLoad(entry.gameObject);
        entry.Score = score;
        entry.gameObject.SetActive(false);
        LeaderboardEntries.Add(entry);
    }

    private void Awake()
    {
        SetSingleton();
        OpenSavedEntries();
        visuals.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            visuals.gameObject.SetActive(true);
            return;
        }
        visuals.gameObject.SetActive(false);
    }

    private void SetSingleton()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(GameObject.Find("Leaderboard Canvas"));
            return;
        }
        Destroy(GetComponentInParent<Canvas>().gameObject);
    }

    private void OpenSavedEntries()
    {
        for(int i = 0; i < 3; i++)
        {
            if (!PlayerPrefs.HasKey($"Highscore{i + 1}")) break;
            MyLeaderboardEntry instance = Instantiate(entryObject, transform.position, Quaternion.identity);
            instance.transform.SetParent(visuals.transform);
            instance.Score = PlayerPrefs.GetInt($"Highscore{i+1}");
            instance.gameObject.SetActive(false);
            LeaderboardEntries.Add(instance);
        }
        OnPlayerCollision();
    }

    public override void OnPlayerCollision()
    {
        SortLeaderboard();
        DisplayLeaderboard();
    }

    private void SortLeaderboard()
    {
        scoreList.Sort();
        foreach(int score in scoreList)
        {
            scoreStack.Push(score);
        }
        for(int i = 0; i < scoreStack.Count; i++)
        {
            LeaderboardEntries[i].Score = scoreStack.Pop();
            LeaderboardEntries[i].Rank = i + 1;
            times++;
        }
    }

    private void DisplayLeaderboard()
    {
        for(int i = 0; i < 3; i++)
        {
            /*MyLeaderboardEntry entry = Instantiate(entryObject, transform.position, Quaternion.identity);
            RectTransform instanceRect = entry.GetComponent<RectTransform>();
            instanceRect.anchoredPosition = new Vector2(referenceAnchor.anchoredPosition.x, referenceAnchor.anchoredPosition.y - height * (i + 1));
            entry.InitializeEntry(Random.Range(0, 90f).ToString());*/
            //RectTransform instanceRect = LeaderboardEntries[i].GetComponent<RectTransform>();
            //instanceRect.anchoredPosition = new Vector2(referenceAnchor.anchoredPosition.x, referenceAnchor.anchoredPosition.y - height * (i + 1));
            if (!LeaderboardEntries[i]) return;
            LeaderboardEntries[i].InitializeEntry($"Rank { LeaderboardEntries[i].Rank}:\t{ LeaderboardEntries[i].Score}");
            PlayerPrefs.SetInt($"Highscore{i+1}", LeaderboardEntries[i].Score);
            PlayerPrefs.Save();
            if(i >= 2)
            {
                LeaderboardEntries.Remove(LeaderboardEntries[i]);
                break;
            }
            if(i < times)
            {
                LeaderboardEntries[i].gameObject.SetActive(true);
                continue;
            }
            LeaderboardEntries[i].gameObject.SetActive(false);
        }
    }
}
