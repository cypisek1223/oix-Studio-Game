using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutOfAreaGame : MonoBehaviour
{
    public Animator OutOfAreaGameAnimator;
    public Text meterText;
    public Canvas outOfAreaGame;
    public float meter;
    public float addTime;
    public float couldown;
    public void Start()
    {
        outOfAreaGame.enabled = false;
        meterText.text = 5.ToString(); 
    }
    private void Update()
    {
        meterText.text = meter.ToString();
        if (float.Parse(meterText.text) <= 0)
        {
            Debug.LogWarning("Przegrana");
        }
    
     }
    public void OnTriggerStay2D(Collider2D other)
    {
        outOfAreaGame.enabled = true;
        if (other.tag == "Player")
        {
            if (addTime <= Time.time)
            {
                addTime = Time.time + couldown;
                meter-=1;
            }

        OutOfAreaGameAnimator.SetBool("OutOfArea", true);
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            outOfAreaGame.enabled = false;
            OutOfAreaGameAnimator.SetBool("OutOfArea", false);
            meter = 5;
        }

    }
}
