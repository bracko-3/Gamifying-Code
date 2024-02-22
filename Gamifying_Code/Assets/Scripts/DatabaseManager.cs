using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase.Extensions;


public class DatabaseManager : MonoBehaviour
{
    // this is where the input field will go, when the start screen is done.
    private string name1 = "Brayden";
    private int score1 = 100;

    private string userID;
    private DatabaseReference dbReference;

    void Start()
    {
        userID = SystemInfo.deviceUniqueIdentifier;
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public void CreateUser(string name, int score)
    {
        User newUser = new User(name1, score1);
        string json = JsonUtility.ToJson(newUser);

        dbReference.Child("users").Child(userID).SetRawJsonValueAsync(json);
    }
}
