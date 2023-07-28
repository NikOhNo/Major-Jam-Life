using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    [RequireComponent(typeof(TMP_Text), typeof(CanvasGroup))]
    public class ScoreDisplay : MonoBehaviour, IDisplay
    {
        TMP_Text tmpText;
        CanvasGroup canvasGroup;

        private void Awake()
        {
            tmpText = GetComponent<TMP_Text>();
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void UpdateScore(int newScore)
        {
            UpdateText($"Score: {newScore}");
        }

        private void UpdateText(string newText)
        {
            tmpText.text = newText;
        }

        public void ShowDisplay()
        {
            canvasGroup.alpha = 1;
        }

        public void HideDisplay()
        {
            canvasGroup.alpha = 0;
        }
    }
}