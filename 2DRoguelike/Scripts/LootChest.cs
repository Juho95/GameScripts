using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootChest : MonoBehaviour
{
    Animator chest_Animator;
    public GameObject roguelikeStatsCanvas;

    // Start is called before the first frame update
    void Start()
    {
        chest_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Osuttiin pelaajaan");
            chest_Animator.SetTrigger("OpenChest");

            //gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.layer = 9;

            //pause the game
            Time.timeScale = 0;

        }
    }
}
