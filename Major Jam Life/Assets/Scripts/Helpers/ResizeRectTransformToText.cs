using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public class ResizeRectTransformToText : MonoBehaviour
    {
        [SerializeField]
        RectTransform rt;

        [SerializeField]
        TMP_Text text;

        public void Resize()
        {
            rt.sizeDelta = new Vector2(rt.sizeDelta.x, text.preferredHeight);
        }

        private void Awake()
        {
            Resize();
        }
    }
}