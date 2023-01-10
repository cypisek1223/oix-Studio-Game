using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTexts : MonoBehaviour
{
    public VariableText variableText;

    public Text text;
    public bool a;
    public int numberText;
    public int numberSize;
    public int numberFonts;


    void Start()
    {
        text.enabled = false;
        text.resizeTextForBestFit = true;
        //text.verticalOverflow =
        text.text = variableText.texts[numberText-1];
        text.fontSize = (int)variableText.fontSize[numberSize-1];
        text.font = variableText.fonts[numberFonts-1];
    }
    private void Update()
    {
        if (a)
        {
            text.enabled = true;
        }
        else
        {
            text.enabled = false;
        }
    }
}
