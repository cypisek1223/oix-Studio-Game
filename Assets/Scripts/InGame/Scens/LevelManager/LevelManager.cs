using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Canvas StartCanvas;
    public Canvas MenuLevel;
    public Animator[] levelBtnAnim;
    public Image[] imageBtn;
    public int numberBtn=0;
    public bool now=false;
    public void Start()
    {
        StartCanvas.enabled = false;
        // MenuLevel.enabled = false;
    }
    public void BtnStartLevelMenu()
    {
       // StartCanvas.enabled = false;
       // MenuLevel.enabled = true;
    }
    public void ResetAnimation(int numberLevel)
    {
        for (int i = 0; i < levelBtnAnim.Length; i++)
        {
            levelBtnAnim[i].SetBool("BtnAnimation", false);
            Debug.LogError("level:"+i+"--"+levelBtnAnim[i].GetBool("BtnAnimation"));
            now = true;     
        }
        if (now)
        {
            Debug.LogError("Dziaola" + numberBtn);
            levelBtnAnim[numberLevel - 1].SetBool("BtnAnimation", true);
            now = false;
        }
    }
    public void BtnStartLevel()
    {
        SceneManager.LoadScene("Level"+ numberBtn);
    }
    public void Btnlevel1()
    {
        numberBtn = 1;
        ResetAnimation(numberBtn);
    }
    public void Btnlevel2()
    {
        numberBtn = 2;
        ResetAnimation(numberBtn);
    }
    public void Btnlevel3()
    {
        numberBtn = 3;
        ResetAnimation(numberBtn);
    }
    public void Btnlevel4()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Btnlevel5()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Btnlevel6()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Btnlevel7()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Btnlevel8()
    {
        SceneManager.LoadScene("Level1");
    }
}
