using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreenLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public static string UserName;
    public static string gameCode;
    public InputField namefield;
    public InputField gameCodeField;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    public void loadNextScene()
    {
        Submit();
        SceneManager.LoadScene(2);
    }
    public void Submit()
    {
        UserName = namefield.text;
        gameCode = gameCodeField.text;
    }
}
