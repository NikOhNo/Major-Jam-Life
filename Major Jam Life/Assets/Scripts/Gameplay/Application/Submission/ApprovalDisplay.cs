using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace Assets.Scripts.Gameplay.Application.Submission
{
    [RequireComponent(typeof(Image))]
    public class ApprovalDisplay : MonoBehaviour
    {
        [SerializeField]
        Sprite approveSprite;

        [SerializeField]
        Sprite denySprite;

        Image image;

        private void Awake()
        {
            // Set transparent
            image = GetComponent<Image>();
            image.color = new Color(1f, 1f, 1f, 0f);
        }

        public void ShowApproved(RectTransform position)
        {
            image.color = Color.white;
            image.sprite = approveSprite;
            image.SetNativeSize();
            GetComponent<RectTransform>().position = position.position;
        }

        public void ShowDenied(RectTransform position)
        {
            image.color = Color.white;
            image.sprite = denySprite;
            image.SetNativeSize();
            GetComponent<RectTransform>().position = position.position;
        }
    }
}