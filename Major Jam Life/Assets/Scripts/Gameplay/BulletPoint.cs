using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

[Serializable]
public class BulletPoint : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public string firstNode;
    public string secondNode;
    public string thirdNode;
    public string fourthNode;

    void Awake()
    {
        dialogueRunner = FindObjectOfType<DialogueRunner>();
    }

    [SerializeField]
    string pointInfo;

    [SerializeField]
    DialogueEntry[] clickDialogue;

    public string PointInfo { get { return pointInfo; } }
    public DialogueEntry[] ClickDialogue { get {  return clickDialogue; } }

    public void firstDescription()
    {
        dialogueRunner.StartDialogue(firstNode);
    }

    public void secondDescription()
    {
        dialogueRunner.StartDialogue(secondNode);
    }

    public void thirdDescription()
    {
        dialogueRunner.StartDialogue(thirdNode);
    }

    public void fourthDescription()
    {
        dialogueRunner.StartDialogue(fourthNode);
    }
}
