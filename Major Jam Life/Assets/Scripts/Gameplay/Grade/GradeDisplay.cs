using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GradeDisplay : MonoBehaviour
{
    [SerializeField]
    TMP_Text gainedText;

    [SerializeField]
    TMP_Text earnedText;

    [SerializeField]
    TMP_Text possibleText;

    [SerializeField]
    TMP_Text commentaryText;

    [SerializeField]
    Button nextDayButton;

    public void SetCommentary(string text)
    {
        commentaryText.text = text;
    }

    public void SetGained(int value)
    {
        gainedText.text = "Gained " + value.ToString();
    }

    public void SetPossible(int value)
    {
        possibleText.text = value.ToString();
    }

    public void SetEarned(int value)
    {
        earnedText.text = value.ToString();
    }

    public void PrepareNextDay(UnityAction action)
    {
        nextDayButton.onClick.AddListener(action);
    }
}
