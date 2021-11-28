using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SuddenDeath : MonoBehaviour
{
    [Tooltip ("Game units per second")]
    [SerializeField] float scrollRate = 0.1f;
    public bool isSuddenDeath;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (!isSuddenDeath)
        {
            return;
        }
        else
        {
            float yMove = scrollRate * Time.deltaTime;
            transform.Translate(new Vector2(0f, yMove));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject, 0.2f);
        }
    }
}

