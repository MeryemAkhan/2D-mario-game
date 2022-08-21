using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CoinText.coinAmount += 5;

            PlayerPrefs.SetInt("miktar", CoinText.coinAmount);  //setınt integer veri tipinde bir veriyi kaydetmek için kullanılır.
            Destroy(gameObject);
        }
    }
}
