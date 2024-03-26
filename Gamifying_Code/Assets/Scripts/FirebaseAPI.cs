using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using FullSerializer;
using Proyecto26;
using System.Linq;

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

    public static IEnumerator GetUsers(string gameCode, System.Action<List<User>> callback)
    {
        string requestURL = $"{databaseURL}{gameCode}.json";
        RestClient.Get<Dictionary<string, User>>(requestURL).Then(response =>
        {
            // Log the raw response to see what we got back
            Debug.Log($"Received data: {response.Count} users");

            // Convert the response dictionary to a list of Users
            List<User> users = response.Values.ToList();

            // Optionally, log the received users' details for further inspection
            foreach (var user in users)
            {
                Debug.Log($"User: {user.userName}, Score: {user.gamifyScore}");
            }

            // Sort the users list in descending order based on gamifyScore
            users.Sort((x, y) => y.gamifyScore.CompareTo(x.gamifyScore));

            // Invoke the callback with the sorted list
            callback(users);
        }).Catch(error =>
        {
            Debug.LogError($"Failed to fetch users: {error}");
        });
        yield return null;
    }
}