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
        public string gameCode;
        public int qAnswered;
        public int qAttempts;

        public User(string userName, string gameCode, int qAnswered, int qAttempts)
        {
            this.userName = userName;
            this.gameCode = gameCode;
            this.qAnswered = qAnswered;
            this.qAttempts = qAttempts;
        }
    }

    // -----------------
    // API Information
    // -----------------

    private const string projectID = "gamifying-code-2024";
    private static readonly string databaseURL = $"https://{projectID}.firebaseio.com/";

    //Initial user info sent to database
    public static void PostUser(User user, string userID)
    {
        RestClient.Put<User>($"{databaseURL}users/{userID}.json", user);
    }
}
