using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public static bool gameIsPaused;
    [SerializeField] GameObject pauseLabel;
    [SerializeField] GameObject paddle;

    private void Awake()
    {
        pauseLabel.SetActive(false);
        Time.timeScale = 1;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }


    }

    void PauseGame()
    {
        if (gameIsPaused)
        {
            pauseLabel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseLabel.SetActive(false);
            Time.timeScale = 1;
            
        }
    }
}
