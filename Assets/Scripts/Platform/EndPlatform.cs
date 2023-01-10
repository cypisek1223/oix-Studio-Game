using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPlatform : MonoBehaviour
{
    public bool endPlatform=false;
    public GameObject loadingText;
    private void Update()
    {
        loadingText.active = false;
        if (GameManager.instance.point >= GameManager.instance.allPoint)
        {
            loadingText.active = true;
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag== "Player" && GameManager.instance.point >= GameManager.instance.allPoint)
        {
            Debug.LogError("On End Platform <-------------------------------------------------");
            //if (GameManager.instance.touchController.playerVelocity == 0)        
                GameManager.instance.touchController.activeMove = false;
                GameManager.instance.kanvasESC.timer = false;
            endPlatform = true;
            GameManager.instance.kanvasESC.ifEndAnimation = true;
            Debug.LogError("ActiveMove"+GameManager.instance.touchController.activeMove);
        }
    }
}
