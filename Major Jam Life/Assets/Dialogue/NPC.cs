using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update
    public DialogueRunner dialogueRunner;
    public string conversationStartNode;

    void Awake()
    {
        dialogueRunner = FindObjectOfType<DialogueRunner>();
    }

    private void StartConversation()
    {
        dialogueRunner.StartDialogue(conversationStartNode);
    }

    // Update is called once per frame
    void Update()
    {
        StartConversation();
    }
}
