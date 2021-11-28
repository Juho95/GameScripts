using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldCoin : MonoBehaviour
{

    public float spinSpeed;
    public CoinWallet cW;
    // Start is called before the first frame update
    void Start()
    {
        cW = GameObject.Find("Player").GetComponent<CoinWallet>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cW.AddCoin(1);

            Destroy(gameObject);

        }
    }

}
