using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VariableText", menuName = "VariableText1")]
public class VariableText : ScriptableObject
{
    public string[] texts;
    public Font[] fonts;
    public float[] fontSize;
    public Transform[] textPosition;

    public FontStyle font4;

   
}