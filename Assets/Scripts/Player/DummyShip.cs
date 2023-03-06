using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyShip : MonoBehaviour
{
    public void Update()
    {
        DelatShip();
    }
    public void DelatShip()
    {
        StartCoroutine(Delet(25f));
    }
    IEnumerator Delet(float duration)
    {       
        yield return new WaitForSeconds(duration);
        Destroy(this.gameObject);
    }
}
