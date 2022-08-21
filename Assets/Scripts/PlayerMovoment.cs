using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovoment : MonoBehaviour
{
    float moveInput; //girdi değeri alıyorum.
    public Rigidbody2D rb;   //oluşturulan rigidbody e referans değişkeni verelim.
    public float speed;  //hız değerini değiştirmek için katsayı değişkeni oluşturulur.
    public Transform pos; //transform özelliklerinden positionu alırız..
    public float jumpForce;  //zıplamasını dereclendirmek için değişken   
    Vector3 velocity;  //hareket vektörü


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  //referansımızı dolduruyoruz. 
    }


    void Update()
    {
        //getaxis girdisi sonucunda hareket vektörünün hesaplanması
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);   //sağa sola hareketi için girdileri alırız.
        transform.position += velocity * speed * Time.deltaTime;  //transform özelliğini posizyonunu hız vektörü ve speed ile çarparak ne kadar hızlı olacağını söylüyoruz.
        //her frame de çalışacağı için düzgün update olması için  her zaman aynı miktarda çalışması için  time.delta time dedim.

        //ınputu kullanarak ilk butona basılma değerini bir kere alması için jump ile alıp gelsin istiyoruz. 
        if (Input.GetButtonDown("Jump") && Mathf.Approximately(rb.velocity.y, 0))  //birden çok zıplamaması için mathf fonksiyonu ile dikey eksende hareketini kontrol ediyoruz 
                                                                                   //bunu da rb nin hız değerini y ekseni olacak şekilde yazarız ve bunun 0 a yakın bir değer olduğunda bu hareketi yapmasını sağlıyoruz.
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);   //rb ye addforce ile dikey eksende kuvvet uyguluyoruz. yukarıya doğru itilmiş gibi olsun diye 
            //yukarı doğru devam etmeyen tek bir anlık kuvvet olması için  ForceMode2d fonksiyonunu ımpluse veriyorum.
        }
        if (Input.GetAxisRaw("Horizontal") == -1)  //karakterin sağa sola dönmesi raw değerini alıp horizontal değeri -1 e eşit olunca 
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);  //rotasyon değerini 180 olarak değiştiriyorum.
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)  //1 olduğunda 
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);  //eski haline yani sağa baktığında 0 derece olmasını sağlıyoruz
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bayrak"))
        {
            int SahneNo = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(SahneNo + 1);
        }
        if (collision.collider.CompareTag("Finish"))
        {
            
            SceneManager.LoadScene("Kazanma");
        }
    }
}
