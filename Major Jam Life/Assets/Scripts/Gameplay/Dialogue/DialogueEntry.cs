using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueEntry
{
    [SerializeField]
    ApplicantInfoSO applicantInfo;
    
    [TextArea(3, 6)]
    [SerializeField]
    string dialogueText;
}