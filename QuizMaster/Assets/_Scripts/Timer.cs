using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;

    public bool loadNextQuestion;
    public bool isAnsweringQuestion;
    public float fillFraction;

    float timerValue;

    void Update()
    {
        UpdateTimer();   
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if (!isAnsweringQuestion)
        {
            if (timerValue <= 0)
            {
                isAnsweringQuestion = true;
                timerValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
            else if (timerValue > 0)
            {
                fillFraction = timerValue / timeToShowCorrectAnswer;
            }
        }
        else if (isAnsweringQuestion)
        {
            if (timerValue <= 0)
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
            else if (timerValue > 0)
            {
                fillFraction = timerValue / timeToCompleteQuestion;
            }
        }
    }

    public void StopTimer()
    {
        timerValue = 0;
    }
}
