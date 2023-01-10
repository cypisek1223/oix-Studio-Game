using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public string MenuLvlName;
    public string MenuSettingName;
    
    public void StartButton()
    {
        SceneManager.LoadScene(MenuLvlName);
    }
    public void SetingButton()
    {
        SceneManager.LoadScene(MenuSettingName);
    }
    public void ExitButton()
    {

    }
}
