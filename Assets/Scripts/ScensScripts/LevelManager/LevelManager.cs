using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject lodingScreen;
    public Canvas lodingScreen1;
    public Slider slider;

    public Canvas startCanvas;
    public Canvas MenuLevel;
    public Animator[] levelBtnAnim;
    public Image[] imageBtn;
    public int numberBtn=0;
    public bool now=false;
    public void Start()
    {
        startCanvas.enabled = false;
        //lodingScreen.SetActive(false);
        lodingScreen1.enabled = false;
        //lodingScreen.enabled = false;
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
        //OPEN LOADINGSCEN
        StartCoroutine(LoadAsynchronously(numberBtn));
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
        numberBtn = 4;
        ResetAnimation(numberBtn);
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
    public void BtnTutorial()
    {
        SceneManager.LoadScene("TutorialLevel1");
    }


    IEnumerator LoadAsynchronously(int scenIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scenIndex);
        lodingScreen1.enabled = true;

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}
