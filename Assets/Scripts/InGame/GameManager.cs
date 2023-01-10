using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //All Scripts
    public Cam cam;
    public TouchController touchController;
    public KanvasESC kanvasESC;
    public RopeHook ropeHook;
    public Rope rope;
    public EndPlatform endPlatform;

    public bool startGame;

    public int point;
    public int allPoint;
     private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
            return;
    }
}
