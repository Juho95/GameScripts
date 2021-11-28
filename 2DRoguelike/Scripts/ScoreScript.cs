using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text scoreValueText;
    public float scoreValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        scoreValueText.text = scoreValue.ToString();
    }


    void Update()
    {
        scoreValue += Time.deltaTime;
        scoreValueText.text = scoreValue.ToString("f1");
        
    }




}
