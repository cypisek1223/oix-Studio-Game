using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Check : MonoBehaviour
{
    public Text timeText;
    public GameObject coins;
    public GameObject check;

    public int howTime;
    public int startime;
    public int numerIndicator;

    public float couldown;
    private float addTime;

    public bool ifEnd;
    public bool endPlatform;
    public bool on=true;

    public MeshRenderer meshCheck;
    public Material green;
    public Material red;
   
    void Start()
    {
        meshCheck = GetComponent<MeshRenderer>();
        meshCheck.material = red;
        ifEnd = false;
        timeText.enabled = false;
        coins.active= false;
        startime = howTime;
    }
    void Update()
    {
        timeText.text = howTime.ToString();
        if(howTime <= 0 && on)
        {
            timeText.enabled = false;
            coins.active = true;
            meshCheck.material = green;
            GameManager.instance.indicator.numberTag = numerIndicator;
            howTime = startime;
            on = false;
            if (endPlatform)
            {
                ifEnd = true;
            }
        }
        if (ifEnd)
        {
            GameManager.instance.endPlatform.endPlatform = true;
            GameManager.instance.endPlatform.loadingText.active = true;
        }
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && on)
        {
            timeText.enabled = true;
            if (addTime <= Time.time&& howTime>=0)
            {
                addTime = Time.time + couldown;
                howTime -= 1;
            }
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" && on)
        {
            timeText.enabled = false;
            howTime = startime;
           meshCheck.material = red;
        }

    }
}
