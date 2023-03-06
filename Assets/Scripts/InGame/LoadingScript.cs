using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    private bool alreadyCalled = false;
    void Start()
    {
        StartCoroutine(LoadYourAsyncScene());
    }
    void Update()
    {
        if (alreadyCalled == false)
        {
            StartCoroutine(LoadYourAsyncScene());
            alreadyCalled = true;
        }
    }
    IEnumerator LoadYourAsyncScene()
    {
        yield return new WaitForSeconds(0.02f);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("StarScen");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

    }
}
