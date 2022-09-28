using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    [SerializeField] Sprite defaultAnswerSprites;
    [SerializeField] Sprite correctAnswerSprites;

    void Start()
    {
        questionText.text = question.GetQuestion();
        
        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
        
    }

    public void OnAnswerSelected(int index)
    {
        int correctAnswerIndex = question.GetCorrectAnswerIndex();
        Image buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
        if (index == correctAnswerIndex)
        {
            questionText.text = "That's the correct answer!";
        }
        else
        {
            questionText.text = $"Sorry, the correct answer was {answerButtons[correctAnswerIndex].GetComponentInChildren<TextMeshProUGUI>().text}";
        }
        buttonImage.sprite = correctAnswerSprites;
    }
}
