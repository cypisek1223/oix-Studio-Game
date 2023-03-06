using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScen : MonoBehaviour
{
    public Canvas lodingScreen;
    public Slider slider;
    public void LoadLevel(int scenIndex)
    {
        StartCoroutine(LoadAsynchronously(scenIndex));
    }
    IEnumerator LoadAsynchronously(int scenIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scenIndex);
        lodingScreen.enabled = true;
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}