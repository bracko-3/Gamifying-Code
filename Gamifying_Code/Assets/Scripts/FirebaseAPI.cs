using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using FullSerializer;
using Proyecto26;
using System.Linq;
using RSG;
using Newtonsoft.Json;

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

    public static void GetUsers(string gameCode, Action<List<List<object>>> callback)
    {
        RestClient.Get($"{databaseURL}{gameCode}.json").Then(response =>
        {
            var usersDict = JsonConvert.DeserializeObject<Dictionary<string, User>>(response.Text);
            var topUsers = usersDict.Values.OrderByDescending(u => u.gamifyScore).Take(10);
            var topUsersList = topUsers.Select(user => new List<object> { user.userName, user.totalQuestions, user.questionsCorrect, user.attacksLanded, user.gamifyScore }).ToList();

            callback?.Invoke(topUsersList); // Invoke the callback with the topUsersList

        }).Catch(error =>
        {
            Debug.LogError(error);
        });
    }
}