using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public int playerOneScore;
    public int playerTwoScore;



    public int round = 1;
    public bool scoreAdded = true;

    public GameObject playerTwoSpawn;
    public GameObject playerTwo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfPlayerDead();
        FinishGame();
    }

    private void CheckIfPlayerDead()
    {
        if (!GameObject.FindGameObjectWithTag("Player"))
        {


        }

        if (!GameObject.FindGameObjectWithTag("Enemy"))
        {


            scoreAdded = false;
            if (!scoreAdded)
            {
                playerOneScore = playerOneScore + 1;
                round = round + 1;
                scoreAdded = true;
                GameObject enemy = Instantiate(playerTwo, playerTwoSpawn.transform.position, Quaternion.identity);
            }
            Debug.Log(playerTwoScore);
        }
    }

    private void FinishGame()
    {
        if (round == 3)
        {
            Debug.Log("Game Finished");

            if (playerOneScore > playerTwoScore)
            {
                Debug.Log("Player 1 won!");
            }

            else
            {
                Debug.Log("Player 2 won!");
            }
        }
    }

}
