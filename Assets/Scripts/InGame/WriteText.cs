using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WriteText : MonoBehaviour
{

    public float delay = 0.1f;
    public string fullText;
    public int stringNumbers=0;
    private string currentText = "";
    private void Start()
    {
        StartCoroutine(ShowText());

        
    }
    
    IEnumerator ShowText()
    {
        for(int i =0; i < fullText.Length; i++)
        {

            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
            if(i<= fullText.Length)
            {
    
            }
        }
    }

}
