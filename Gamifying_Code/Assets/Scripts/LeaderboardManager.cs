using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LeaderboardManager : MonoBehaviour
{
    private GameObject quizManager;
    public GameObject rowPrefab; // Assign in the inspector
    public Transform tableTransform; // The parent for the rows, assign in the inspector
    private int quizPercent;

    // Add these to interact with Firebase
    public string gameCode = "TSTCD1";

    private void Start()
    {
        LoadLeaderboard();
    }

    public void AddRowToTable(int place, string name, int gamifyScore, float quizPercentage, int attacksLanded)
    {
        GameObject newRow = Instantiate(rowPrefab, tableTransform);
        newRow.GetComponent<LeaderboardRow>().SetRowData(place, name, gamifyScore, quizPercentage, attacksLanded);
    }

    public void LoadLeaderboard()
    {
        StartCoroutine(FirebaseAPI.GetUsers(gameCode, ProcessLeaderboardData));
    }

    private void ProcessLeaderboardData(List<FirebaseAPI.User> users)
    {
        // Clear existing rows if necessary
        foreach (Transform child in tableTransform)
        {
            Destroy(child.gameObject);
        }

        // Add a new row for each user
        int place = 1; // Initialize place counter
        foreach (var user in users)
        {
            // Correctly calculate quizPercentage for each user
            int quizPercent = user.totalQuestions > 0 ? (int)Math.Round((float)user.questionsCorrect / user.totalQuestions * 100) : 0;
            // Pass quizPercent as an argument instead of quizPercentage
            AddRowToTable(place, user.userName, user.gamifyScore, quizPercent, user.attacksLanded);
            place++;
        }
    }
}