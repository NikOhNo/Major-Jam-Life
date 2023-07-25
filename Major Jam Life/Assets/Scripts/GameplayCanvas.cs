using Assets.Scripts.Systems;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(CanvasGroup))]
    public class GameplayCanvas : MonoBehaviour
    {
        // Serialized Fields
        [SerializeField]
        ScoreDisplay scoreDisplay;

        // Cached References
        CanvasGroup canvasGroup;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Initialize(ScoreManager scoreManager)
        {
            if (scoreManager == null)
            {
                throw new ArgumentNullException(nameof(scoreManager));
            }

            scoreManager.ScoreChanged.AddListener(scoreDisplay.UpdateScore);
            scoreDisplay.UpdateScore(scoreManager.Score);
        }

        public void SetInteractable(bool enabled)
        {
            canvasGroup.interactable = enabled;
        }

        public void ShowUI()
        {
            canvasGroup.alpha = 1.0f;
        }

        public void HideUI()
        {
            canvasGroup.alpha = 0f;
        }
    }
}
