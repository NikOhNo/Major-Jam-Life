using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Responder : MonoBehaviour
{
    [SerializeField]
    TMP_Text tmpText;

    [SerializeField]
    Button button;

    public void SetText(string text)
    {
        tmpText.text = text;
    }

    public void AddListener(UnityAction call)
    {
        button.onClick.AddListener(call);
    }
}
