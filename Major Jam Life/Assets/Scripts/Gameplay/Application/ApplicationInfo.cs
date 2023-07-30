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
    SketchInfoSO sketchInfo;

    [SerializeField]
    List<BulletPoint> bulletPoints;

    [SerializeField]
    List<QuestionInfoSO> questions;

    public List<DialogueEntry> IntroDialogue { get => introDialogue; }
    public ApplicantInfoSO ApplicantInfo { get => applicantInfo; }
    public SketchInfoSO SketchInfo { get => sketchInfo; }
    public List<BulletPoint> BulletPoints { get => bulletPoints; }
    public List<QuestionInfoSO> Questions { get => questions; }
}
