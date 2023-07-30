using Assets.Scripts.Helpers;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Gameplay
{
    public class BulletPointDisplay : MonoBehaviour
    {
        BulletPoint bulletPoint;

        // Cached References
        TMP_Text tmpText;
        Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
            tmpText = GetComponentInChildren<TMP_Text>();
        }

        public void Initialize(BulletPoint bulletPoint)
        {
            this.bulletPoint = bulletPoint;

            tmpText.text = $"• {bulletPoint.PointInfo}";
            GetComponent<ResizeRectTransformToText>().Resize();
            // Subscribe to the dialogue manager to click
            //button.onClick.AddListener(() => FunctionToStartDialogue(bulletPoint.ClickDialogue));
        }
    }
}