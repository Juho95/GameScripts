using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformer : MonoBehaviour
{

    public float lifetime = 10f;
    public float timeRemaining = 10f;
    public bool platformTimerIsRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        platformTimerIsRunning = true;
        Destroy(gameObject, timeRemaining);

    }

    // Update is called once per frame

    private void Update()
    {
        if (platformTimerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                platformTimerIsRunning = false;
            }
        }

        if(timeRemaining <= 3f && timeRemaining > 1f)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }

        else if (timeRemaining <= 1f) {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }

    }

}
