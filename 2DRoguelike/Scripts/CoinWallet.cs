using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinWallet : MonoBehaviour
{
    public Text coinAmountText;
    public int coinAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        coinAmountText = GameObject.Find("CoinText").GetComponent<Text>();
        coinAmountText.text = coinAmount.ToString();
    }


    void Update()
    {
        
    }

    public void AddCoin(int coins)
    {
        coinAmount = coinAmount + coins;
        coinAmountText.text = coinAmount.ToString();
    }
}
