using Assets.Scripts.Systems;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Gameplay
{
    [RequireComponent(typeof(Image), typeof(CanvasGroup))]
    public class ApplicantDisplay : MonoBehaviour, IDisplay
    {
        Image image;
        CanvasGroup canvasGroup;

        ApplicantInfoSO applicantInfo;

        private void Awake()
        {
            image = GetComponent<Image>();
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Initialize(ApplicantInfoSO applicantInfo)
        {
            this.applicantInfo = applicantInfo;

            SetSprite(applicantInfo.Sprite);
        }

        public void SetSprite(Sprite newSprite)
        {
            image.sprite = newSprite;
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