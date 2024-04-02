using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
     public int scoreGive = 500;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            {
                Game.obj.addScore(scoreGive);

                AudioManager.obj.playWin();

                UIManager.obj.updateScore();

                gameObject.SetActive(false);

                Win.obj.showEndPanel();
            }
    }
}
