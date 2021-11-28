using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    public float currentSpeed;
    public float growingSpeed= 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        currentSpeed = rb.velocity.x;
        Debug.Log(rb.velocity.x);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpeed < 0)
        {
            currentSpeed -= Time.deltaTime;
            Debug.Log(currentSpeed);
            rb.velocity = new Vector2(currentSpeed, 0);
        }
        else
        {
            currentSpeed += Time.deltaTime;
            Debug.Log(currentSpeed);
            rb.velocity = new Vector2(currentSpeed, 0);
        }
        gameObject.transform.position = new Vector2(transform.position.x, 0 + transform.localScale.y / 2);
        growingSpeed += Time.deltaTime;
        gameObject.transform.localScale = new Vector2(1, growingSpeed);
    }
}
