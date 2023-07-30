using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SketchInfo", menuName = "New Sketch Info")]
public class SketchInfoSO : ScriptableObject
{
    [SerializeField]
    string sketchName;

    [SerializeField]
    Sprite sketch;

    public string SketchName { get { return sketchName; } } 
    public Sprite Sketch { get {  return sketch; } }
}
