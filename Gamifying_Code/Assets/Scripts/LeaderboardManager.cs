using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LeaderboardManager : MonoBehaviour
{
    public GameObject rowPrefab; // Assign in the inspector
    public Transform tableTransform; // The parent for the rows, assign in the inspector

    public void AddRowToTable(int place, string name, int gamifyScore, float quizPercentage, int attacksLanded)
    {
        // Instantiate a new row
        GameObject newRow = Instantiate(rowPrefab, tableTransform);
        
        // Set the data for the new row
        newRow.GetComponent<LeaderboardRow>().SetRowData(place, name, gamifyScore, quizPercentage, attacksLanded);
    }
}
