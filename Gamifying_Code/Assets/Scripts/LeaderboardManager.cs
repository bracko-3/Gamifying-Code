using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Newtonsoft.Json;

public class LeaderboardManager : MonoBehaviour
{
    public List<List<object>> leaderboardInfo;
    public string gameCode;

    void Start()
    {
        gameCode = "TSTCD1";
        leaderboardInfo = new List<List<object>>();

        // get leaderboard info
        FirebaseAPI.GetUsers(gameCode, HandleTopUsers);
    }

    private void HandleTopUsers(List<List<object>> topUsers)
    {
        // Use the topUsers list here
        foreach (var userScorePair in topUsers)
        {
            leaderboardInfo.Add(userScorePair);
        }

        // Log the contents of leaderboardInfo as a JSON string
        string json = JsonConvert.SerializeObject(leaderboardInfo);
        Debug.Log($"from LEADERBOARDINFO: {json}");

        updateLeaderboard();
    }

    void Update()
    {
        
    }
    
    // [userName, totalQuestions, questionsCorrect, attacksLanded, gamifyScore]

    // Static leaderboard
    public Text place1;
    public Text name1;
    public Text attacksLanded1;
    public Text quizPercentText1;
    public Text gamifyScore1;
    private int quizPercent1;

    public void updateLeaderboard() 
    {
        int totalQuestions = Convert.ToInt32(leaderboardInfo[0][1]);
        int questionsCorrect = Convert.ToInt32(leaderboardInfo[0][2]);
        quizPercent1 = (int)Math.Round((float)questionsCorrect / totalQuestions * 100);
        place1.text = "1";
        name1.text = leaderboardInfo[0][0].ToString();
        attacksLanded1.text = leaderboardInfo[0][3].ToString();
        quizPercentText1.text = $"{quizPercent1}%";
        gamifyScore1.text = leaderboardInfo[0][4].ToString();
    }
}
