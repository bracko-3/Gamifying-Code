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

        public User(string userName, int totalQuestions, int questionsCorrect)
        {
            this.userName = userName;
            this.totalQuestions = totalQuestions;
            this.questionsCorrect = questionsCorrect;
        }

        // Method to update qAnswered
        public void SetTotalQuestions(int value)
        {
            totalQuestions = value;
        }

        // Method to update qAttempts
        public void SetQuestionsCorrect(int value)
        {
            questionsCorrect = value;
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