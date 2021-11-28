using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameSession : MonoBehaviour
{
    //config params
    [SerializeField] float pointsPerBlockDestroyed = 1;
    [SerializeField] public Text scoreText;
    [SerializeField] bool isAutoPlayEnabled;
    [SerializeField] public GameObject gameCanvas;

    // state variables
    public static float currentScore = 0;

    public int highScore = 0;
    public int saveScore;

    // Start is called before the first frame update

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        
    }
    void Start()
    {

        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = currentScore.ToString();
        pointsPerBlockDestroyed = Ball.yPush;

    }

    public void AddtoScore()
    {
        currentScore = Mathf.Floor(currentScore + pointsPerBlockDestroyed); //currentScore =+ pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()

    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

    public string yourScore()
    {
        return scoreText.text;
    }

    public int saveHighScore()
    {
        saveScore = Int32.Parse(scoreText.text);
        if(saveScore >= highScore)
        {
            highScore = saveScore;
        }

        return highScore;
    }

    public void turnGameCanvasOff()
    {
        gameCanvas.SetActive(false);

    }

    public void turnGameCanvasOn()
    {
        gameCanvas.SetActive(true);

    }
}

