using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QuestionAnswerPair
{
    [SerializeField]
    QuestionInfoSO questionInfoSO;

    [SerializeField]
    int correctIndex;

    public QuestionInfoSO QuestionInfoSO { get {  return questionInfoSO; } }
    public int CorrectIndex { get { return correctIndex; } }

}
