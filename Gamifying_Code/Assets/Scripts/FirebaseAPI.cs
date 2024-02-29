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
        public int qAnswered;
        public int qAttempts;

        public User(string userName, int qAnswered, int qAttempts)
        {
            this.userName = userName;
            this.qAnswered = qAnswered;
            this.qAttempts = qAttempts;
        }

        // Method to update qAnswered
        public void SetQAnswered(int value)
        {
            qAnswered = value;
        }

        // Method to update qAttempts
        public void SetQAttempts(int value)
        {
            qAttempts = value;
        }
    }

    // Base URL - never changes
    private static readonly string databaseURL = "https://gamifying-code-2024-default-rtdb.firebaseio.com/";

    // First call to the database to input user
    public static void PostUser(User user, string gameCode, string userID)
    {
        RestClient.Put<User>($"{databaseURL}{gameCode}/{userID}.json", user);
    }
}
