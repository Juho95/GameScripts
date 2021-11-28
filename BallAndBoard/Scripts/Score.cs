using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public Text ScoreText;
    GameSession theGameSession;
    [SerializeField] public Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        ScoreText.text = theGameSession.yourScore();
        highScoreText.text = theGameSession.saveHighScore().ToString();
        // Destroy(GameObject.Find("Game Session"));
    }
    // Update is called once per frame

}