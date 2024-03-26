using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StartScreenLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public static string UserName;
    public static string gameCode;
    public TMP_InputField namefield;
    public TMP_InputField gameCodeField;
    void Start()
    {
        // namefield = GameObject.FindGameObjectWithTag("NameField");
        //  gameCodeField = GameObject.FindGameObjectWithTag("GameCode");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void loadNextScene()
    {
        Submit();
        SceneManager.LoadScene(1);
    }
    void Submit()
    {
        {
            UserName = namefield.text;
            gameCode = gameCodeField.text;


        }
    }
}

