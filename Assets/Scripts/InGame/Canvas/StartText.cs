using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartText : MonoBehaviour
{
    public Image startText;
    public Sprite Go;
    public Sprite Ready;

    public Vector3 startPosition;
    public bool startTextBool;
    public bool run;
    public float speed;
    public float addTime;

    void Start()
    {
        
        //Time.timeScale = 0f;
        startPosition = transform.position;
        startText.sprite = Ready;
        startText.enabled = true;
    }
    void Update()
    {
        float clock = Time.time;
        
    }
}
