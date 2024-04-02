using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puf : MonoBehaviour
{
    public static Puf obj;

    private void Awake() 
    {
        obj = this;   
    }

    public void show(Vector3 pos)
    {
        transform.position = pos;
        gameObject.SetActive(true);
    }
    public void dissapear()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy() {
        obj = null;
    }
}
