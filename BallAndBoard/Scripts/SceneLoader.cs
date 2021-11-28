using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    int currentSceneIndex;
    GameSession theGameSession;
    PauseControl pauseControl;




    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime(4));
        }

        if (SceneManager.GetSceneByName("Game Complete").isLoaded)
        {
            OnCompleteScene();
        }

    }



    IEnumerator WaitForTime(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void LoadFirstScene()
    {
        SceneManager.LoadScene("Level 1");
        if (GameObject.Find("Game Session") != null && !theGameSession.gameCanvas.activeInHierarchy)
        {
            theGameSession.turnGameCanvasOn();
        }
        GameSession.currentScore = 0;
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        Ball.yPush = 10;
    }

    public void LoadStartScene()
    {

        SceneManager.LoadScene("Main Menu");
        Ball.yPush = 10;
        if (GameObject.Find("Game Session") != null && !theGameSession.gameCanvas.activeInHierarchy) {
            theGameSession.turnGameCanvasOff();
        }
    }
    public void LoadLevelSelectScene()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void LoadOptionsScene()
    {
        SceneManager.LoadScene("Options");
        Ball.yPush = 10; 
    }

    public void Select(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    private void OnCompleteScene()
    {
        if (GameObject.Find("Game Session") != null && theGameSession.gameCanvas.activeInHierarchy)
        {
            theGameSession.turnGameCanvasOff();
        }
    }
}
