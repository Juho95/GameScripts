using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SessionController : MonoBehaviour
{
    public Button chairButton;
    public Button tableButton;
    public Button planeButton;
    public Button uiButton;
    public Button quitButton;
    public Slider slider;
    public GameObject mainCanvas;

    public bool isChairSelected = false;
    public bool isTableSelected = false;
    public bool isPlaneSelected = false;
    public bool isCanvasActive = true;
    public GameObject objectToScale = null;



    private void Update()
    {

        if (isTableSelected)
        {
            if (GameObject.Find("table(Clone)") != null)
            {
                objectToScale = GameObject.Find("table(Clone)");
                objectToScale.transform.localScale = new Vector3(slider.value * 4, slider.value * 4, slider.value * 4);
            }
        }

        if (isPlaneSelected)
        {
            if (GameObject.Find("PlaneObject(Clone)") != null)
            {
                objectToScale = GameObject.Find("PlaneObject(Clone)");
                objectToScale.transform.localScale = new Vector3(slider.value / 8, slider.value / 8, slider.value / 8);
            }
        }

        if (isChairSelected)
        {
            if (GameObject.Find("chair2(Clone)") != null)
            {
                objectToScale = GameObject.Find("chair2(Clone)");
                objectToScale.transform.localScale = new Vector3(slider.value, slider.value, slider.value);
            }
        }
    }


    public void QuitGame()
    {
        Debug.Log("Painettiin");
        Application.Quit();
    }

    public void ChangeChairButtonColor()
    {
        chairButton.GetComponent<Image>().color = Color.green;
        tableButton.GetComponent<Image>().color = Color.white;
        planeButton.GetComponent<Image>().color = Color.white;
        isTableSelected = false;
        isChairSelected = true;
        isPlaneSelected = false;
    }

    public void ChangeTableButtonColor()
    {
        chairButton.GetComponent<Image>().color = Color.white;
        tableButton.GetComponent<Image>().color = Color.green;
        planeButton.GetComponent<Image>().color = Color.white;
        isTableSelected = true;
        isChairSelected = false;
        isPlaneSelected = false;
    }

    public void ChangePlaneButtonColor()
    {
        chairButton.GetComponent<Image>().color = Color.white;
        tableButton.GetComponent<Image>().color = Color.white;
        planeButton.GetComponent<Image>().color = Color.green;
        isTableSelected = false;
        isChairSelected = false;
        isPlaneSelected = true;
    }

    public void ChangeQuitButtonColor()
    {
        quitButton.GetComponent<Image>().color = Color.red;

    }

    public void HideUI()
    {
        if (isCanvasActive)
        {
            uiButton.GetComponent<Image>().color = Color.green;
            mainCanvas.SetActive(false);
            isCanvasActive = false;
        }

        else if (!isCanvasActive)
        {
            uiButton.GetComponent<Image>().color = Color.white;
            mainCanvas.SetActive(true);
            isCanvasActive = true;
        }
    }

}
