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
        ResponderDisplay responderDisplay;

        int selectedResponseIndex;

        private void Awake()
        {
            button = GetComponent<Button>();
            textDisplay = GetComponentInChildren<TMP_Text>();
        }

        public void Initialize(QuestionInfoSO questionInfo, GameObject responderDisplayObject)
        {
            this.questionInfo = questionInfo;

            textDisplay.text = questionInfo.Question;
            this.responderDisplay = responderDisplayObject.GetComponent<ResponderDisplay>();
            button.onClick.AddListener(() => ActivateResponder(this.questionInfo));
        }

        public void ActivateResponder(QuestionInfoSO question)
        {
            Debug.Log($"Displaying question: {question.Question}");

            // Activate panel
            responderDisplay.SetActive(true);

            // Create response buttons
            for (int i = 0; i < question.PossibleResponses.Count; i++)
            {
                string currResponse = question.PossibleResponses[i];
                int index = i;  // need to do this to avoid captured variable issue

                // Assign index and add onclick to set selected to that
                responderDisplay.CreateResponder(this, currResponse, index);
            }
        }

        public void SetSelectedResponse(int index)
        {
            Debug.Log($"Chose response: {questionInfo.PossibleResponses[index]}");

            // Set selected
            selectedResponseIndex = index;

            // Clear and hide the responder
            responderDisplay.ClearAllResponders();
            responderDisplay.SetActive(false);
        }
    }
}