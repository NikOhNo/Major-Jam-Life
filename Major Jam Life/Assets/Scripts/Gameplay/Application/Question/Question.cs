using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assets.Scripts.Gameplay.Application.Question
{
    [RequireComponent(typeof(Button))]
    public class Question : MonoBehaviour
    {
        Button button;
        TMP_Text textDisplay;
        QuestionInfoSO questionInfo;

        int selectedResponseIndex;

        private void Awake()
        {
            button = GetComponent<Button>();
            textDisplay = GetComponentInChildren<TMP_Text>();
        }

        public void Initialize(QuestionInfoSO questionInfo, GameObject responder)
        {
            this.questionInfo = questionInfo;

            textDisplay.text = questionInfo.Question;
            button.onClick.AddListener(() => DisplayResponder(this.questionInfo, responder));
        }

        public void DisplayResponder(QuestionInfoSO question, GameObject responder)
        {
            Debug.Log($"Displaying question: {question.Question}");

            // Activate panel
            responder.SetActive(true);

            // Create response buttons
            foreach (string answer in question.PossibleResponses)
            {
                // Assign index and add onclick to set selected to that
            }
        }
    }
}