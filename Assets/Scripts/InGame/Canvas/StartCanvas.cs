using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCanvas : MonoBehaviour
{
    public void StartLevelManager()
    {
        SceneManager.LoadScene("LevelManager");
    }
}
