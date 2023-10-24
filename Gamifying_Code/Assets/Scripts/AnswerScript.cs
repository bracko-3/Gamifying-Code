using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

    //starting color of the button - used to change when button is selected.
    public Color startColor;

    private void Start()
    {
        startColor = GetComponent<Image>().color;
    }

    public void Answer()
    {
        if(isCorrect)
        {
            GetComponent<Image>().color = Color.green;
            Debug.Log("Correct Answer");
            quizManager.correct();
        }
        else
        {
            GetComponent<Button>().interactable = false;
            GetComponent<Image>().color = Color.red;
            Debug.Log("Wrong Answer");

            for (int i = 0; i < quizManager.options.Length; i++)
            {
                if (quizManager.options[i].GetComponent<Button>().interactable == true)
                {
                    StartCoroutine(delayForAnswers(i));
                }
            }
        }
    }

    //Two second delay when you get a question wrong. Wrong answer stays inactive the whole time.
    public IEnumerator delayForAnswers(int optionNumber)
    {
        quizManager.options[optionNumber].GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(2);
        quizManager.options[optionNumber].GetComponent<Button>().interactable = true;
    }
}