using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    [RequireComponent(typeof(TMP_Text))]
    public class ScoreDisplay : MonoBehaviour
    {
        TMP_Text tmpText;

        private void Awake()
        {
            tmpText = GetComponent<TMP_Text>();
        }

        public void UpdateScore(int newScore)
        {
            UpdateText($"Score: {newScore}");
        }

        private void UpdateText(string newText)
        {
            tmpText.text = newText;
        }
    }
}