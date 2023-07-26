using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update
    public DialogueRunner dialogueRunner;
    public string conversationStartNode;
    public string firstNode;
    public string secondNode;
    public string thirdNode;
    public string fourthNode;

    void Awake()
    {
        dialogueRunner = FindObjectOfType<DialogueRunner>();
    }

    // private void StartConversation()
    // {
    //     dialogueRunner.StartDialogue(conversationStartNode);
    // }

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

    // Update is called once per frame
    void Update()
    {
        //StartConversation();
    }
}
