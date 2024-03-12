using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using FullSerializer;
using Proyecto26;

public class FirebaseAPI : MonoBehaviour
{
    // User class and constructor used to send data to firebase
    public class User
    {
        public string userName;
        public int totalQuestions;
        public int questionsCorrect;
        public int attacksLanded;
        public int attacksFailed;
        public int gamifyScore;

        public User(string userName, int totalQuestions, int questionsCorrect, int attacksLanded, int attacksFailed, int gamifyScore)
        {
            this.userName = userName;
            this.totalQuestions = totalQuestions;
            this.questionsCorrect = questionsCorrect;
            this.attacksLanded = attacksLanded;
            this.attacksFailed = attacksFailed;
            this.gamifyScore = gamifyScore;
        }
    }

    // Base URL - never changes
    private static readonly string databaseURL = "https://gamifying-code-2024-default-rtdb.firebaseio.com/";

    // Send user information to the database
    public static void PostUser(User user, string gameCode, string userID)
    {
        RestClient.Put<User>($"{databaseURL}{gameCode}/{userID}.json", user);
    }
}