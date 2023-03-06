using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TutorialLevel1 : MonoBehaviour
{
    public GameObject arrow1, arrow2;
   
    public void Start()
    {
        arrow1.active = true;
        arrow2.active = false;
    }
    public void Update()
    {
        
        if (GameManager.instance.indicator.numberTag == 2)
        {
            arrow2.active = true;
        }
        if (GameManager.instance.indicator.numberTag >= 6)
        {
            arrow1.active = false;
            GameManager.instance.endPlatform.loadingText.active = true;
        }
        if (GameManager.instance.endPlatform.endPlatform)
        { 
                SceneManager.LoadScene("TutorialLevel2");         
        }
    }
}
