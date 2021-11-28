using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverInfo : MonoBehaviour
{

    [SerializeField] GameObject infoLabel;

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
        infoLabel.SetActive(true);
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
        infoLabel.SetActive(false);
    }
}