using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    public static FXManager obj;
    public GameObject pop;
    public GameObject puf;

    void Awake()
    {
        obj = this;
    }

    public void showPop(Vector3 pos) 
    {
        pop.gameObject.GetComponent<Pop>().show(pos);
    }

    public void showPuf(Vector3 pos)
    {
        puf.gameObject.GetComponent<Puf>().show(pos);
    }

    void OnDestroy() {
        obj = null;
    }
}
