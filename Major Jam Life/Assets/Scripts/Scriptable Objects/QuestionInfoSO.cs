using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuestionInfo", menuName = "New Question")]
public class QuestionInfoSO : ScriptableObject
{
    [SerializeField]
    string question;

    [SerializeField]
    List<string> possibleResponses;

    [SerializeField]
    int expectedResponseIndex;

    public string Question { get => question; }
    public List<string> PossibleResponses { get => possibleResponses; }
    public int ExpectedResponseIndex { get => expectedResponseIndex; }
}
