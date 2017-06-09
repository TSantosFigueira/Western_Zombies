using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public int leaderboardSize;

    public Text[] playerNames;
    public Text[] playerScores;
    public Text currentScore;

    public static List<PlayerScore> generalScore;


    //! Retrieves leaderboard, if it does not exist all values are set with standard values
	void Start () {
        PlayerScore.localScore = 0;

        generalScore = new List<PlayerScore>(leaderboardSize);

        for (int i = 0; i < leaderboardSize; i++)
        {
            PlayerScore player = new PlayerScore();
            player.playerName = PlayerPrefs.GetString("name " + i.ToString(), "..."); ;
            player.score = PlayerPrefs.GetInt("score" + i, 000); ;

            generalScore.Add(player);
        }
	}

    //! Adds new player score to the leaderboard
    public void AddScore(string name, int score)
    {
        PlayerScore player = new PlayerScore();
        player.playerName = name;
        player.score = score;

        generalScore.Add(player);
        generalScore.Sort();

        while (generalScore.Count > leaderboardSize)
        {
            generalScore.RemoveAt(leaderboardSize - 1);
        }

        SaveScore();
    }

    //! Saves current stored values to player prefs
    private void SaveScore()
    {
        for (int i = 0; i < generalScore.Count; i++)
        {
         //   PlayerPrefs.SetString("name" + i, generalScore[i].playerName);
            PlayerPrefs.SetInt("score" + i, generalScore[i].score);
        }
        PlayerPrefs.Save();
    }

    public void DisplayLeaderboard()
    {
        for (int i = 0; i < generalScore.Count; i++)
        {
          //  playerNames[i].text = generalScore[i].playerName;
            playerScores[i].text = generalScore[i].score.ToString();
        }
    }

    private void Update()
    {
        currentScore.text = PlayerScore.localScore.ToString();
        if (PauseManager.isPaused)
        {
            currentScore.text = "";
        }
    }
}
