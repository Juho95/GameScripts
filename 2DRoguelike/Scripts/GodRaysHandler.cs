using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodRaysHandler : MonoBehaviour
{
    GameObject player;
    public float spinSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1.5f);
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = player.transform.position;
        transform.Rotate(0,0,spinSpeed * Time.deltaTime);
    }
}
