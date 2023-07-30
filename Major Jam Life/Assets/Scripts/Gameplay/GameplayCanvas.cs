using Assets.Scripts.Gameplay;
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

        [SerializeField]
        ApplicationDisplay applicationDisplay;

        [SerializeField]
        ApplicantDisplay characterDisplay;

        // Cached References
        CanvasGroup canvasGroup;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Initialize(ScoreManager scoreManager, ApplicationInfo applicationInfo)
        {
            if (scoreManager == null)
            {
                throw new ArgumentNullException(nameof(scoreManager));
            }

            scoreManager.ScoreChanged.AddListener(scoreDisplay.UpdateScore);
            scoreDisplay.UpdateScore(scoreManager.Score);

            characterDisplay.Initialize(applicationInfo.ApplicantInfo);
            characterDisplay.ShowDisplay();

            applicationDisplay.Initialize(applicationInfo);
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
