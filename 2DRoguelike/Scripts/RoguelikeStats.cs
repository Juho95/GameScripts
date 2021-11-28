
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RoguelikeStats : MonoBehaviour
{

    public Sprite[] StatsSprites;
    public Sprite[] tempStatsSprites;
    public GameObject stats_1;
    public GameObject stats_2;
    public GameObject stats_3;
    public int randomElement;

    // Start is called before the first frame update
    private void OnEnable()
    {
        //Create temporary array from all the possible affixes.
        tempStatsSprites = new Sprite[StatsSprites.Length];
        Array.Copy(StatsSprites, tempStatsSprites, StatsSprites.Length);

        //Affix number 1
        stats_1 = gameObject.transform.GetChild(1).gameObject;
        randomElement = UnityEngine.Random.Range(0, StatsSprites.Length);
        stats_1.GetComponent<Image>().sprite = StatsSprites[randomElement];
        RemoveElement(ref StatsSprites, randomElement);

        //Affix number 2
        stats_2 = gameObject.transform.GetChild(2).gameObject;
        randomElement = UnityEngine.Random.Range(0, StatsSprites.Length);
        stats_2.GetComponent<Image>().sprite = StatsSprites[randomElement];
        RemoveElement(ref StatsSprites, randomElement);

        //Affix number 3
        stats_3 = gameObject.transform.GetChild(3).gameObject;
        randomElement = UnityEngine.Random.Range(0, StatsSprites.Length);
        stats_3.GetComponent<Image>().sprite = StatsSprites[randomElement];
        RemoveElement(ref StatsSprites, randomElement);


        for (int i = 1; i < gameObject.transform.childCount; i++)
        {
            if(gameObject.transform.GetChild(i).gameObject.GetComponent<Image>().sprite == tempStatsSprites[0])
            {
                gameObject.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text = "Increase Attack DMG";
            }
            if (gameObject.transform.GetChild(i).gameObject.GetComponent<Image>().sprite == tempStatsSprites[1])
            {
                gameObject.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text = "Increase Movement Speed";
            }
            if (gameObject.transform.GetChild(i).gameObject.GetComponent<Image>().sprite == tempStatsSprites[2])
            {
                gameObject.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text = "Decrease Dash Cooldown";
            }
            if (gameObject.transform.GetChild(i).gameObject.GetComponent<Image>().sprite == tempStatsSprites[3])
            {
                gameObject.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text = "Increase max health, but doesn't restore health";
            }
            if (gameObject.transform.GetChild(i).gameObject.GetComponent<Image>().sprite == tempStatsSprites[4])
            {
                gameObject.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text = "Restore Health";
            }
            if (gameObject.transform.GetChild(i).gameObject.GetComponent<Image>().sprite == tempStatsSprites[5])
            {
                gameObject.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text = "Increase Fireball DMG";
            }
            if (gameObject.transform.GetChild(i).gameObject.GetComponent<Image>().sprite == tempStatsSprites[6])
            {
                gameObject.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text = "Decrease Fireball Cooldown";
            }
            if (gameObject.transform.GetChild(i).gameObject.GetComponent<Image>().sprite == tempStatsSprites[7])
            {
                gameObject.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text = "Get 5 gold coins";
            }
            if (gameObject.transform.GetChild(i).gameObject.GetComponent<Image>().sprite == tempStatsSprites[8])
            {
                gameObject.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<Text>().text = "Increase critical hit chance";
            }

        }
    }

    void OnDisable()
    {
        //Reset the StatsSprites to be some as in start
        StatsSprites = new Sprite[tempStatsSprites.Length];
        Array.Copy(tempStatsSprites, StatsSprites, tempStatsSprites.Length);
        stats_1 = null;
        stats_2 = null;
        stats_3 = null;
    }

    private void RemoveElement<T>(ref T[] arr, int index)
    {
        for (int i = index; i < arr.Length - 1; i++)
        {
            arr[i] = arr[i + 1];
        }

        Array.Resize(ref arr, arr.Length - 1);
    }

}
