using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject platform;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                GameObject newPlatform = Instantiate(platform, new Vector3(x, y, 0), Quaternion.identity);
                if (x % 2 == 0 && y % 2 == 0)
                {
                    newPlatform.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                }
                else if(y % 2 != 0 && x % 2 != 0)
                {
                    newPlatform.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                }
                else 
                {
                    newPlatform.GetComponent<Renderer>().material.SetColor("_Color", Color.cyan);
                }
            }
        }

        GameObject Player1 = Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
        Player1.name = "Player1";
        Player1.tag = "Player1";
        Player1.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        Player1.transform.rotation = Quaternion.Euler(90, 0, 0);
        GameObject Player2 = Instantiate(player, new Vector3(7, 7, 0), Quaternion.identity);
        Player2.name = "Player2";
        Player2.tag = "Player2";
        Player2.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        Player2.transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
