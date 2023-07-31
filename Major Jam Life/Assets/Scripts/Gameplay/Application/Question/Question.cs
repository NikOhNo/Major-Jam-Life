using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Assets.Scripts.Gameplay.Application.Question
{
    [RequireComponent(typeof(Button))]
    public class Question : MonoBehaviour
    {
        [SerializeField]
        TMP_Text questionText;

        [SerializeField]
        TMP_Text selectedText;

        Button button;
        QuestionAnswerPair questionAnswerPair;
        ResponderDisplay responderDisplay;

        int selectedResponseIndex;

        private void Awake()
        {
            button = GetComponent<Button>();
            selectedText.text = "";
        }

        public void Initialize(QuestionAnswerPair questionAnswerPair, GameObject responderDisplayObject)
        {
            this.questionAnswerPair = questionAnswerPair;

            questionText.text = this.questionAnswerPair.QuestionInfoSO.Question;
            this.responderDisplay = responderDisplayObject.GetComponent<ResponderDisplay>();
            button.onClick.AddListener(() => ActivateResponder(questionAnswerPair.QuestionInfoSO));
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
            string chosenResponse = questionAnswerPair.QuestionInfoSO.PossibleResponses[index];
            Debug.Log($"Chose response: {chosenResponse}");

            // Set selected
            selectedResponseIndex = index;

            // Display selected
            selectedText.text = chosenResponse;

            // Clear and hide the responder
            responderDisplay.ClearAllResponders();
            responderDisplay.SetActive(false);

            FindObjectOfType<SoundManager>().PlayPencilScribble();
        }

        public QuestionResult GetResult()
        {
            return new QuestionResult()
            {
                IsCorrect = selectedResponseIndex == questionAnswerPair.CorrectIndex,
                Response = questionAnswerPair.QuestionInfoSO.PossibleResponses[selectedResponseIndex]
            };
        }
    }
}