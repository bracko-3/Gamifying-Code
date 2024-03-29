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
        gameCode = "testgame1";
        leaderboardInfo = new List<List<object>>();

        // get leaderboard info
        StartCoroutine(GetUsersEveryFiveSeconds());
    }

    IEnumerator GetUsersEveryFiveSeconds()
    {
        while (true)
        {
            // Call your function to get users
            FirebaseAPI.GetUsers(gameCode, HandleTopUsers);

            // Wait for 5 seconds
            yield return new WaitForSeconds(5f);
        }
    }

    private void HandleTopUsers(List<List<object>> topUsers)
    {
        // clear list
        leaderboardInfo.Clear();

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
        if (leaderboardInfo.Count >= 1) updateLeaderboard1();
        if (leaderboardInfo.Count >= 2) updateLeaderboard2();
        if (leaderboardInfo.Count >= 3) updateLeaderboard3();
        if (leaderboardInfo.Count >= 4) updateLeaderboard4();
        if (leaderboardInfo.Count >= 5) updateLeaderboard5();
        if (leaderboardInfo.Count >= 6) updateLeaderboard6();
        if (leaderboardInfo.Count >= 7) updateLeaderboard7();
        if (leaderboardInfo.Count >= 8) updateLeaderboard8();
        if (leaderboardInfo.Count >= 9) updateLeaderboard9();
        if (leaderboardInfo.Count >= 10) updateLeaderboard10();
    }
    
    // [userName, totalQuestions, questionsCorrect, attacksLanded, gamifyScore]

    // ########################################
    // Leaderboard row 1
    // ########################################
    public Text place1;
    public Text name1;
    public Text attacksLanded1;
    public Text quizPercentText1;
    public Text gamifyScore1;
    private int quizPercent1;

    public void updateLeaderboard1()
    {
        int totalQuestions1 = Convert.ToInt32(leaderboardInfo[0][1]);
        int questionsCorrect1 = Convert.ToInt32(leaderboardInfo[0][2]);
        quizPercent1 = (int)Math.Round((float)questionsCorrect1 / totalQuestions1 * 100);
        place1.text = "1";
        name1.text = leaderboardInfo[0][0].ToString();
        attacksLanded1.text = leaderboardInfo[0][3].ToString();
        quizPercentText1.text = $"{quizPercent1}%";
        gamifyScore1.text = leaderboardInfo[0][4].ToString();
    }

    // ########################################
    // Leaderboard row 2
    // ########################################
    public Text place2;
    public Text name2;
    public Text attacksLanded2;
    public Text quizPercentText2;
    public Text gamifyScore2;
    private int quizPercent2;

    public void updateLeaderboard2()
    {
        int totalQuestions2 = Convert.ToInt32(leaderboardInfo[1][1]);
        int questionsCorrect2 = Convert.ToInt32(leaderboardInfo[1][2]);
        quizPercent2 = (int)Math.Round((float)questionsCorrect2 / totalQuestions2 * 100);
        place2.text = "2";
        name2.text = leaderboardInfo[1][0].ToString();
        attacksLanded2.text = leaderboardInfo[1][3].ToString();
        quizPercentText2.text = $"{quizPercent2}%";
        gamifyScore2.text = leaderboardInfo[1][4].ToString();
    }

    // ########################################
    // Leaderboard row 3
    // ########################################
    public Text place3;
    public Text name3;
    public Text attacksLanded3;
    public Text quizPercentText3;
    public Text gamifyScore3;
    private int quizPercent3;

    public void updateLeaderboard3()
    {
        int totalQuestions3 = Convert.ToInt32(leaderboardInfo[2][1]);
        int questionsCorrect3 = Convert.ToInt32(leaderboardInfo[2][2]);
        quizPercent3 = (int)Math.Round((float)questionsCorrect3 / totalQuestions3 * 100);
        place3.text = "3";
        name3.text = leaderboardInfo[2][0].ToString();
        attacksLanded3.text = leaderboardInfo[2][3].ToString();
        quizPercentText3.text = $"{quizPercent3}%";
        gamifyScore3.text = leaderboardInfo[2][4].ToString();
    }

    // ########################################
    // Leaderboard row 4
    // ########################################
    public Text place4;
    public Text name4;
    public Text attacksLanded4;
    public Text quizPercentText4;
    public Text gamifyScore4;
    private int quizPercent4;

    public void updateLeaderboard4()
    {
        int totalQuestions4 = Convert.ToInt32(leaderboardInfo[3][1]);
        int questionsCorrect4 = Convert.ToInt32(leaderboardInfo[3][2]);
        quizPercent4 = (int)Math.Round((float)questionsCorrect4 / totalQuestions4 * 100);
        place4.text = "4";
        name4.text = leaderboardInfo[3][0].ToString();
        attacksLanded4.text = leaderboardInfo[3][3].ToString();
        quizPercentText4.text = $"{quizPercent4}%";
        gamifyScore4.text = leaderboardInfo[3][4].ToString();
    }

    // ########################################
    // Leaderboard row 5
    // ########################################
    public Text place5;
    public Text name5;
    public Text attacksLanded5;
    public Text quizPercentText5;
    public Text gamifyScore5;
    private int quizPercent5;

    public void updateLeaderboard5()
    {
        int totalQuestions5 = Convert.ToInt32(leaderboardInfo[4][1]);
        int questionsCorrect5 = Convert.ToInt32(leaderboardInfo[4][2]);
        quizPercent5 = (int)Math.Round((float)questionsCorrect5 / totalQuestions5 * 100);
        place5.text = "5";
        name5.text = leaderboardInfo[4][0].ToString();
        attacksLanded5.text = leaderboardInfo[4][3].ToString();
        quizPercentText5.text = $"{quizPercent5}%";
        gamifyScore5.text = leaderboardInfo[4][4].ToString();
    }

    // ########################################
    // Leaderboard row 6
    // ########################################
    public Text place6;
    public Text name6;
    public Text attacksLanded6;
    public Text quizPercentText6;
    public Text gamifyScore6;
    private int quizPercent6;

    public void updateLeaderboard6()
    {
        int totalQuestions6 = Convert.ToInt32(leaderboardInfo[5][1]);
        int questionsCorrect6 = Convert.ToInt32(leaderboardInfo[5][2]);
        quizPercent6 = (int)Math.Round((float)questionsCorrect6 / totalQuestions6 * 100);
        place6.text = "6";
        name6.text = leaderboardInfo[5][0].ToString();
        attacksLanded6.text = leaderboardInfo[5][3].ToString();
        quizPercentText6.text = $"{quizPercent6}%";
        gamifyScore6.text = leaderboardInfo[5][4].ToString();
    }

    // ########################################
    // Leaderboard row 7
    // ########################################
    public Text place7;
    public Text name7;
    public Text attacksLanded7;
    public Text quizPercentText7;
    public Text gamifyScore7;
    private int quizPercent7;

    public void updateLeaderboard7()
    {
        int totalQuestions7 = Convert.ToInt32(leaderboardInfo[6][1]);
        int questionsCorrect7 = Convert.ToInt32(leaderboardInfo[6][2]);
        quizPercent7 = (int)Math.Round((float)questionsCorrect7 / totalQuestions7 * 100);
        place7.text = "7";
        name7.text = leaderboardInfo[6][0].ToString();
        attacksLanded7.text = leaderboardInfo[6][3].ToString();
        quizPercentText7.text = $"{quizPercent7}%";
        gamifyScore7.text = leaderboardInfo[6][4].ToString();
    }

    // ########################################
    // Leaderboard row 8
    // ########################################
    public Text place8;
    public Text name8;
    public Text attacksLanded8;
    public Text quizPercentText8;
    public Text gamifyScore8;
    private int quizPercent8;

    public void updateLeaderboard8()
    {
        int totalQuestions8 = Convert.ToInt32(leaderboardInfo[7][1]);
        int questionsCorrect8 = Convert.ToInt32(leaderboardInfo[7][2]);
        quizPercent8 = (int)Math.Round((float)questionsCorrect8 / totalQuestions8 * 100);
        place8.text = "8";
        name8.text = leaderboardInfo[7][0].ToString();
        attacksLanded8.text = leaderboardInfo[7][3].ToString();
        quizPercentText8.text = $"{quizPercent8}%";
        gamifyScore8.text = leaderboardInfo[7][4].ToString();
    }

    // ########################################
    // Leaderboard row 9
    // ########################################
    public Text place9;
    public Text name9;
    public Text attacksLanded9;
    public Text quizPercentText9;
    public Text gamifyScore9;
    private int quizPercent9;

    public void updateLeaderboard9()
    {
        int totalQuestions9 = Convert.ToInt32(leaderboardInfo[8][1]);
        int questionsCorrect9 = Convert.ToInt32(leaderboardInfo[8][2]);
        quizPercent9 = (int)Math.Round((float)questionsCorrect9 / totalQuestions9 * 100);
        place9.text = "9";
        name9.text = leaderboardInfo[8][0].ToString();
        attacksLanded9.text = leaderboardInfo[8][3].ToString();
        quizPercentText9.text = $"{quizPercent9}%";
        gamifyScore9.text = leaderboardInfo[8][4].ToString();
    }

    // ########################################
    // Leaderboard row 10
    // ########################################
    public Text place10;
    public Text name10;
    public Text attacksLanded10;
    public Text quizPercentText10;
    public Text gamifyScore10;
    private int quizPercent10;

    public void updateLeaderboard10()
    {
        int totalQuestions10 = Convert.ToInt32(leaderboardInfo[9][1]);
        int questionsCorrect10 = Convert.ToInt32(leaderboardInfo[9][2]);
        quizPercent10 = (int)Math.Round((float)questionsCorrect10 / totalQuestions10 * 100);
        place10.text = "10";
        name10.text = leaderboardInfo[9][0].ToString();
        attacksLanded10.text = leaderboardInfo[9][3].ToString();
        quizPercentText10.text = $"{quizPercent10}%";
        gamifyScore10.text = leaderboardInfo[9][4].ToString();
    }
}
