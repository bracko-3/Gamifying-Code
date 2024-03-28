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
    }

    void Update()
    {
        
    }
    
    // Static leaderboard
    public Text place1;
    public Text name1;
    public Text attacksLanded1;
    public Text quizPercent1;
    public Text gamifyScore1;


}
