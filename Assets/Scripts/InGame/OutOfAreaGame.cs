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
    public bool on;
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
        if (on)
        {
            if (addTime <= Time.time)
            {
                addTime = Time.time + couldown;
                meter -= 1;
            }
        }
    
     }
    public void OnTriggerEnter2D(Collider2D other)
    {    
        if (other.tag == "Player")
        {
            outOfAreaGame.enabled = true;
            on = true;
            OutOfAreaGameAnimator.SetBool("OutOfArea", true);
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {       
        if (other.tag == "Player")
        {
            outOfAreaGame.enabled = false;
            on = false;
            //OutOfAreaGameAnimator.SetBool("OutOfArea", false);
            meter = 5;
        }

    }
}
