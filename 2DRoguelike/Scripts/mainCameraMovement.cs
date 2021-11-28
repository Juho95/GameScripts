using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCameraMovement : MonoBehaviour
{
    public GameObject toFollow;

    void Start()
    {
        toFollow = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = toFollow.transform.position.x;
        transform.position = pos;
    }

}
