using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KanvasESC : MonoBehaviour
{
    public TouchController tC;
    public Canvas canvasEscPanel;
    public Canvas canvasEndPanel;
    public Animator animPanel;
    public Animator animStartText;
    public Animator animEnd;

    public bool invoke;
    public bool joyStickRopeSee = false;
    public bool timer;
    public bool ifStarAnimation;
    public bool ifEndAnimation;
    public bool run;

    public Text textTime;
    public Text textPoint;

    public float timmer;
    public float addTimer;

    public double howAdd;
    private double addToText;
    //public float rellyTime = Time.time;
    public void Start()
    {
        canvasEscPanel.enabled = true;
        canvasEndPanel.enabled = false;
        invoke = false;
        addTimer = 0;

    }
    public void FixedUpdate()
    {
        timmer = Time.time;
        textTime.text = addToText.ToString();
        textPoint.text = GameManager.instance.point+"/"+GameManager.instance.allPoint;
        timer = GameManager.instance.touchController.activeMove;
     
        if (Input.touchCount > 0)
        {
            //startText.sprite = Go;
            run = true;

        }
        if (run)
        {
            GameManager.instance.kanvasESC.ifStarAnimation = true;
            //startText.sprite = default;
            run = false;

        }

        if (addTimer <= Time.time)
           {
              addTimer = Time.time + 0.2f;
              addToText += howAdd;         
           }
        if (ifStarAnimation)
        {
            animStartText.SetBool("startAnimation", true);
        }
        if (ifEndAnimation)
        {
            animEnd.SetBool("endAnimation", true);
            canvasEndPanel.enabled = true;
        }   
    }
    public void FreezTime()
    {
        //Time.timeScale = 0;
    }
    public void StartTime()
    {
        //Time.timeScale = 1;
    }
    
    public void BtnESC()
    {
        canvasEscPanel.enabled = true;

        animPanel.SetBool("On",true);
        animPanel.SetBool("Off", false);
        GameManager.instance.touchController.activeMove = false;
      
       //Invoke(nameof(FreezTime), 0.75f);
    }
    public void BtnReturn()
    {
        Time.timeScale = 1;
        animPanel.SetBool("On", false);
        animPanel.SetBool("Off", true);
        //Invoke("StartTime", 0);
        //if (GameManager.instance.endPlatform ==false)
        //{
            GameManager.instance.touchController.activeMove = true;
        //}
    }
    public void BtnReturnLevelMenu()
    {
        SceneManager.LoadScene("LevelManager");
    }
    public void BtnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void BtnNextLvl1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void BtnNextLvl2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void BtnNextLvl3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void BtnTutorial2()
    {
        SceneManager.LoadScene("TutorialLevel2");
    }
    public void RopeLine() 
    {
        joyStickRopeSee =!joyStickRopeSee;
    }

    public void BtnTouchController()
    {
        GameManager.instance.touchController.butons = false;
        //tC.butons = false;
        //Debug.LogError("TouchController!!!!!!!!!!!!!!!!!");
    }
    public void BtnButtonController()
    {
        GameManager.instance.touchController.butons = true;
        //tC.butons = true;
       //Debug.LogError("ButtonController!!!!!!!!!!!!!!!!!");
    }
}
