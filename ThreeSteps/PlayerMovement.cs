using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Text playerTurn;

    public bool playerOneTurn = true;
    public bool playerTwoTurn = false;
    public GameObject controlledUnit = null; // instead of GameObject, could use custom type like ControllableUnit
    public Vector3 playerCurrentPosition;
    public Vector3 positionToMove;
    public int amountOfMoves;
    public int maxMovesOnTurn = 3;

    // Start is called before the first frame update
    void Start()
    {
        playerTurn.text = "Player, make your move";
        playerOneTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        SelectPlayer();
        MoveSelectedPlayer();
        ChangeTurn();

    }
    public void SelectPlayer()
    {
        if (Input.GetMouseButtonUp(0) && playerOneTurn)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) // you can also only accept hits to some layer and put your selectable units in this layer
            {
                if (hit.collider.tag == "Player1")
                {
                    controlledUnit = hit.transform.gameObject; // if using custom type, cast the result to type here
                    playerCurrentPosition = controlledUnit.transform.position;
                }
                else
                {
                    controlledUnit = null;
                }
            }

        }

        if (Input.GetMouseButtonUp(0) && playerTwoTurn)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) // you can also only accept hits to some layer and put your selectable units in this layer
            {
                if (hit.collider.tag == "Player2")
                {
                    controlledUnit = hit.transform.gameObject; // if using custom type, cast the result to type here
                    playerCurrentPosition = controlledUnit.transform.position;
                }
                else
                {
                    controlledUnit = null;
                }
            }

        }
    }

    public void MoveSelectedPlayer()
    {
        if (controlledUnit != null && amountOfMoves < 3)
        {
            //Detect when the up arrow key is pressed down
            if (Input.GetKeyDown(KeyCode.UpArrow) && playerCurrentPosition.y < 7)
            {

                if (controlledUnit.GetComponent<PlayerHandler>().SearchUp())
                {
                    controlledUnit.transform.position = new Vector3(playerCurrentPosition.x, playerCurrentPosition.y + 1, 0);
                    playerCurrentPosition = controlledUnit.transform.position;
                    amountOfMoves++;
                }
                else
                {
                    Debug.Log("NO PLATFORM TO MOVE UP");
                }


            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && playerCurrentPosition.y > 0)
            {
                if (controlledUnit.GetComponent<PlayerHandler>().SearchDown())
                {
                    controlledUnit.transform.position = new Vector3(playerCurrentPosition.x, playerCurrentPosition.y - 1, 0);
                    playerCurrentPosition = controlledUnit.transform.position;
                    amountOfMoves++;
                }
                else
                {
                    Debug.Log("NO PLATFORM TO MOVE Down");
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) && playerCurrentPosition.x > 0)
            {
                if (controlledUnit.GetComponent<PlayerHandler>().SearchLeft())
                {
                    controlledUnit.transform.position = new Vector3(playerCurrentPosition.x - 1, playerCurrentPosition.y, 0);
                    playerCurrentPosition = controlledUnit.transform.position;
                    amountOfMoves++;
                }
                else
                {
                    Debug.Log("NO PLATFORM TO MOVE LEFT");
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) && playerCurrentPosition.x < 7)
            {
                if (controlledUnit.GetComponent<PlayerHandler>().SearchRight())
                {
                    controlledUnit.transform.position = new Vector3(playerCurrentPosition.x + 1, playerCurrentPosition.y, 0);
                    playerCurrentPosition = controlledUnit.transform.position;
                    amountOfMoves++;
                }
                else
                {
                    Debug.Log("NO PLATFORM TO MOVE RIGHT");
                }
            }


        }

    }




    public void ChangeTurn()
    {
        if (amountOfMoves == 3 && playerOneTurn)
        {
            controlledUnit = null;
            amountOfMoves = 0;
            playerOneTurn = false;
            playerTwoTurn = true;
        }

        else if (amountOfMoves == 3 && playerTwoTurn)
        {
            controlledUnit = null;
            amountOfMoves = 0;
            playerOneTurn = true;
            playerTwoTurn = false;
        }
    }
}
