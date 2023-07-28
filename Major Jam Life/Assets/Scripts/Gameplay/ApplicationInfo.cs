using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationInfo : MonoBehaviour
{
    [SerializeField]
    List<DialogueEntry> introDialogue;

    [SerializeField]
    ApplicantInfoSO applicantInfo;

    [SerializeField]
    Sprite sketch;

    [SerializeField]
    List<BulletPoint> bulletPoints;

    [SerializeField]
    List<Question> questions;

    public List<DialogueEntry> IntroDialogue { get => introDialogue; }
    public ApplicantInfoSO ApplicantInfo { get => applicantInfo; }
    public Sprite Sketch { get => sketch; }
    public List<BulletPoint> BulletPoints { get => bulletPoints; }
    public List<Question> Questions { get => questions; }
}
