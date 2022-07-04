using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    Text text;
    // Static olan metotlara ve özelliklere ise nesne oluşturmadan sınıf adı ile erişiriz. Bu nedenle altın miktarını static olarak tanımladım 
    //diğer sınıflardan buna sınıf adı ile erişebilmek için..
    public static int coinAmount;


    void Start()
    {
        text = GetComponent<Text>();  
    }

    // Update is called once per frame
    void Update()
    {

        text.text = coinAmount.ToString();  // coinAmount objesinin türünü string formatında alıyoruz.

    }
}
