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
        RestClient.Get(requestURL).Then(response =>
        {
            Debug.Log($"Raw JSON response: {response.Text}");

            // Attempt to deserialize the response into a dictionary
            var usersDict = JsonUtility.FromJson<Dictionary<string, User>>(response.Text);
            if (usersDict != null)
            {
                // Convert the dictionary to a list of Users
                List<User> usersList = usersDict.Values.ToList();

                // Sort the users list in descending order based on gamifyScore
                usersList.Sort((x, y) => y.gamifyScore.CompareTo(x.gamifyScore));

                // If there are more than 10 users, limit the list to the top 10
                if (usersList.Count > 10)
                {
                    usersList = usersList.Take(10).ToList();
                }

                // Invoke the callback with the sorted and limited list
                callback(usersList);
            }
            else
            {
                Debug.LogWarning("Failed to deserialize users.");
            }
        }).Catch(error =>
        {
            Debug.LogError($"Failed to fetch users: {error}");
        });
        yield return null;
    }
}