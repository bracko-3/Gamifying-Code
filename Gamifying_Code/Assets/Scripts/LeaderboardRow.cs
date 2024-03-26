using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LeaderboardRow : MonoBehaviour
{
    public Text placeText;
    public Text nameText;
    public Text gamifyText;
    public Text quizPercentageText;
    public Text attacksLandedText;
    
    // Method to set the data for the row
    public void SetRowData(int place, string name, int gamifyScore, float quizPercentage, int attacksLanded)
    {
        placeText.text = place.ToString();
        nameText.text = name;
        gamifyText.text = gamifyScore.ToString();
        quizPercentageText.text = $"{quizPercentage}%";
        attacksLandedText.text = attacksLanded.ToString();
    }
}
