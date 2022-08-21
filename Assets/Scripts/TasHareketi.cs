using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TasHareketi : MonoBehaviour
{
    public float speed;  //hız değerini değiştirmek için katsayı değişkeni oluşturulur.
    public Rigidbody2D rb;   //oluşturulan rigidbody e referans değişkeni verelim.

    bool facingleft;  //sola hareketi için

    // Update is called once per frame
    void Update()
    {
         //Transform bileşeninde translate fonksiyonunu çağır ve fonksiyona oluşturduğum Vector2 sınıfını göndeririz.
        transform.Translate(Vector2.left * speed * Time.deltaTime);  //translate fonk sayesinde objenin position değerini speed ile çarpıp bunu her bir saniyede işlem yapması için time deltatime olarak yazarız.
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        // Optimizasyonun iyi olması ve daha hızlı olduğu için compare tag kullandım..
        //nesne player dışında başka yere çarpması durumunda yön değiştirmesi için..
        if ( collision != null && !collision.collider.CompareTag("Player") && collision.collider.CompareTag("tas"))
        {
            facingleft = !facingleft;  //düsmanın sağa mı sola mı döneceğini çarpışmanın eşit olup olmayacaığını kontrol ederiz.
        }
        
        if (facingleft)  //eğer sola dönükse..
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);  //objenin rotation değerini 0 larız.
        }

        else  //değilsee
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);   //objenin rotation değerinden y yi 180 yaparız diğer tarafa dönmesi için larız.
        }
        
    }
}
