using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewApplicant", menuName = "New Applicant", order = 0)]
public class ApplicantInfoSO : ScriptableObject
{
    [SerializeField]
    string characterName;

    [SerializeField]
    Sprite sprite;

    [SerializeField]
    AudioClip voice;

    public string CharacterName { get { return characterName; } }
    public Sprite Sprite { get { return sprite; } }
    public AudioClip Voice { get {  return voice; } }

}
