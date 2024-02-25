using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FirebaseAPI : MonoBehaviour
{

    private string databaseURL = "https://gamifying-code-2024.firebaseio.com/";

    // -----------------------------------
    // Send player date to database
    // -----------------------------------

    // Method to send player data to Firebase
    public void SendPlayerData(string playerName, int questionAttempts, int questionsAnswered)
    {
        // Construct the data to send
        string jsonData = $"{{\"name\": \"{playerName}\", \"questionAttempts\": {questionAttempts}, \"questionsAnswered\": {questionsAnswered}}}";
        string path = "players"; // The path where you want to store the data in your Firebase database
        StartCoroutine(PutDataCoroutine($"{databaseURL}{path}.json", jsonData));
    }

    // Coroutine to send the PUT request to Firebase
    IEnumerator PutDataCoroutine(string url, string jsonData)
    {
        var request = new UnityWebRequest(url, "PUT");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(request.error);
        }

        else
        {
            Debug.Log("Data successfully sent to Firebase: " + request.downloadHandler.text);
        }
    }

    // -----------------------------------
    // Update player data
    // -----------------------------------

    // Method to update player data by unique ID
    public void UpdatePlayerData(string playerId, string playerName, int questionAttempts, int questionsAnswered)
    {
        // Construct the JSON data string with the player's updated information
        string playerDataJson = $"{{\"name\": \"{playerName}\", \"questionAttempts\": {questionAttempts}, \"questionsAnswered\": {questionsAnswered}}}";

        // Start the coroutine to send the update request
        StartCoroutine(UpdateDataCoroutine($"players/{playerId}.json", playerDataJson));
    }

    IEnumerator UpdateDataCoroutine(string path, string jsonData)
    {
        // Complete URL to the specific player's data
        string url = $"{databaseURL}{path}";

        // Create a PATCH request to update the player's data
        var request = new UnityWebRequest(url, "PATCH");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        // Send the request and wait for the response
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError($"Error updating player data: {request.error}");
        }
        else
        {
            Debug.Log("Player data successfully updated.");
        }
    }
}
