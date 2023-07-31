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

    List<Question> questions = new List<Question>();

    private void Awake()
    {
        responder.SetActive(false);
    }

    public void Initialize(ApplicationInfo applicationInfo)
    {
        CreateQuestions(applicationInfo);
    }

    public void CreateQuestions(ApplicationInfo applicationInfo)
    {
        foreach (QuestionAnswerPair qaPair in applicationInfo.Questions)
        {
            GameObject newQuestionButton = Instantiate(questionButtonPrefab, questionButtonsParent);
            Question newQuestion = newQuestionButton.GetComponent<Question>();
            newQuestion.Initialize(qaPair, responder);

            questions.Add(newQuestion);
        }
    }

    public List<QuestionResult> GetResults()
    {
        List<QuestionResult> results = new List<QuestionResult>();

        foreach (Question q in questions)
        {
            results.Add(q.GetResult());
        }

        return results;
    }
}
