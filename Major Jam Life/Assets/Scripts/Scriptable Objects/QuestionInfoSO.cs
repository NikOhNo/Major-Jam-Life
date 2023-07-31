using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuestionInfo", menuName = "New Question")]
[Serializable]
public class QuestionInfoSO : ScriptableObject
{
    [SerializeField]
    string question;

    [SerializeField]
    List<string> possibleResponses;

    public string Question { get => question; }
    public List<string> PossibleResponses { get => possibleResponses; }
}
