using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagPlayer : MonoBehaviour
{
    public GameObject Player;
    void Update()
    {
        transform.position = Player.transform.position;
    }
}
