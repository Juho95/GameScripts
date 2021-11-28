using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    private PlacementIndicator placementIndicator;
    public GameObject[] objects;
    public GameObject button;
    bool chairInsta = false;
    bool tableInsta = false;
    bool planeInsta = false;

    private void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();
    }

    private void Update()
    {


        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) 
        {
            if (chairInsta)
            {
                IfChairExists();
            }
            if (tableInsta)
            {
                IfTableExists();
            }

            if (planeInsta)
            {
                IfPlaneExists();
            }
        }



    }

    private void IfTableExists()
    {
        if (GameObject.Find("table(Clone)") != null)
        {
            Destroy(GameObject.Find("table(Clone)"));

        }
        else if (GameObject.Find("table(Clone)") == null)
        {
            GameObject obj = Instantiate(objectToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);
        }
    }
    
    private void IfChairExists()
    {
        if (GameObject.Find("chair2(Clone)") != null)
        {
            Destroy(GameObject.Find("chair2(Clone)"));

        }
        else if (GameObject.Find("chair2(Clone)") == null)
        {
            GameObject obj = Instantiate(objectToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);
        }
    }

    private void IfPlaneExists()
    {
        if (GameObject.Find("PlaneObject(Clone)") != null)
        {
            Destroy(GameObject.Find("PlaneObject(Clone)"));

        }
        else if (GameObject.Find("PlaneObject(Clone)") == null)
        {
            GameObject obj = Instantiate(objectToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);
        }
    }


    public void InstantiateTable()
    {
        Debug.Log("Luodaan table");
        objectToSpawn = objects[1];
        tableInsta = true;
        chairInsta = false;
        planeInsta = false;
    }

    public void InstantiateChair()
    {
        Debug.Log("Luodaan chair");
        objectToSpawn = objects[0];
        tableInsta = false;
        chairInsta = true;
        planeInsta = false;
    }

    public void InstantiatePlane()
    {
        Debug.Log("Luodaan plane");
        objectToSpawn = objects[2];
        tableInsta = false;
        chairInsta = false;
        planeInsta = true;
    }
}
