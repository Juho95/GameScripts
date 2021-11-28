using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    GameSession theGameSession;

    private void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Ball"))
            {
            SceneManager.LoadScene("Game Over");
            theGameSession.turnGameCanvasOff();
            Ball.yPush = 10;

        }
        else
        {
            Destroy(collision.gameObject);
        }
    }

    
}
