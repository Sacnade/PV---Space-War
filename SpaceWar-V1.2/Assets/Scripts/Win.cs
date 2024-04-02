using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public static Win obj;

    public GameObject villanos;

    private int i;

    void Awake()
    {
        obj = this;
    }

    private void Start() {
        gameObject.SetActive(false);

    }

    public void showEndPanel()
    {
        gameObject.SetActive(true);
        Game.obj.gamePaused = true;
        villanos.SetActive(false);
    }    

    void OnDestroy() {
        obj = null;
    }
}
