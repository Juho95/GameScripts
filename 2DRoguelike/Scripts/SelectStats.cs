using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectStats : MonoBehaviour
{
    public Sprite[] sprites;
    public GameObject player;
    public HealthBar healthBar;

    public GameObject lightEffect;



    // Start is called before the first frame update

    void OnEnable()
    {
        player = GameObject.Find("Player");
        RoguelikeStats s = gameObject.transform.parent.GetComponent<RoguelikeStats>();
        Debug.Log(s.tempStatsSprites.Length);


        sprites = new Sprite[s.tempStatsSprites.Length];
        for (int i = 0; i < s.tempStatsSprites.Length; i++)
        {
            sprites[i] = s.tempStatsSprites[i];
        }
    }



    public void AddChosenStats()
    {
 
        if (gameObject.GetComponent<Image>().sprite == sprites[0])
        {
            player.GetComponent<PlayerCombat>().attackDamage++;
            player.GetComponent<PlayerCombat>().tempAttackDamage++;
            Debug.Log("New damage is: " + player.GetComponent<PlayerCombat>().attackDamage);
        }
        if (gameObject.GetComponent<Image>().sprite == sprites[1])
        {
            player.GetComponent<Player>().runSpeed++; ;
            Debug.Log("New runspeed is: " + player.GetComponent<Player>().runSpeed);
        }
        if (gameObject.GetComponent<Image>().sprite == sprites[2])
        {
            Debug.Log("New dash cooldown is: ");
        }
        if (gameObject.GetComponent<Image>().sprite == sprites[3])
        {
            healthBar.IncreaseMaxHealth();
            Debug.Log("New max health is: " + healthBar.slider.maxValue);
        }
        if (gameObject.GetComponent<Image>().sprite == sprites[4])
        {
            healthBar.RestoreHealth(player.GetComponent<PlayerHealth>().currentHealth);
            Debug.Log("Restored health.");
        }
        if (gameObject.GetComponent<Image>().sprite == sprites[5])
        {
            player.GetComponent<PlayerCombat>().fireBallDamage++;
            Debug.Log("New fireball damage is: " + player.GetComponent<PlayerCombat>().fireBallDamage);
        }
        if (gameObject.GetComponent<Image>().sprite == sprites[6])
        {
            player.GetComponent<PlayerCombat>().rangedAttackRate += 0.1f;
            Debug.Log("New fireball cooldown is: " + player.GetComponent<PlayerCombat>().rangedAttackRate);
        }
        if (gameObject.GetComponent<Image>().sprite == sprites[7])
        {
            player.GetComponent<CoinWallet>().AddCoin(5);
        }

        if (gameObject.GetComponent<Image>().sprite == sprites[8])
        {
            player.GetComponent<PlayerCombat>().critChance += 5;
            Debug.Log("New critical hit chance is: " + player.GetComponent<PlayerCombat>().critChance);
        }

        Time.timeScale = 1;

        Instantiate(lightEffect, player.transform.position, Quaternion.identity);

        gameObject.transform.parent.gameObject.SetActive(false);

    }
}
