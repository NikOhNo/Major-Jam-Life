using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

[Serializable]
public class BulletPoint
{
    [SerializeField]
    string pointInfo;

    [SerializeField]
    DialogueEntry[] clickDialogue;

    public string PointInfo { get { return pointInfo; } }
    public DialogueEntry[] ClickDialogue { get {  return clickDialogue; } }
}
