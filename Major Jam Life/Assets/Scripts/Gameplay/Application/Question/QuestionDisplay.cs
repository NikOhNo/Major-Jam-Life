using Assets.Scripts.Gameplay.Application.Question;
using Assets.Scripts.Gameplay.Application.Submission;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionDisplay : MonoBehaviour
{
    [SerializeField]
    Transform questionButtonsParent;

    [SerializeField]
    GameObject questionButtonPrefab;

    [SerializeField]
    GameObject responder;

    Submission submission;

    private void Awake()
    {
        responder.SetActive(false);
    }

    public void Initialize(ApplicationInfo applicationInfo, Submission submission)
    {
        this.submission = submission;

        CreateQuestions(applicationInfo);
    }

    public void CreateQuestions(ApplicationInfo applicationInfo)
    {
        foreach (QuestionInfoSO questionInfo in applicationInfo.Questions)
        {
            GameObject newQuestionButton = Instantiate(questionButtonPrefab, questionButtonsParent);

            newQuestionButton.GetComponent<Question>().Initialize(questionInfo, responder);
        }
    }
}
