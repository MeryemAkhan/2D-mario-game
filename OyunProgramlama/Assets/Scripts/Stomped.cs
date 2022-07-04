using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomped : MonoBehaviour
{
    public float force;  //güç değişkeni
    bool stomed = false;  //düşmanı ezme(ölme) işlemi için değişken false olarak verildi..
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Player"))
        {
            Rigidbody2D playerRb = trigger.GetComponent<Rigidbody2D>();
            playerRb.AddForce(Vector2.up * force);   //player a ne kadar güç ile zıplama olacak onu addforce ile hesaplarız
            stomed = true;
            BoxCollider2D boxCollider = transform.parent.gameObject.GetComponent<BoxCollider2D>();
            boxCollider.enabled = false;    //enabled : Collider bileşeninin aktif olup olmayacağını belirttiğimiz değişken.

        }
    }

    //düşmanın yok olmasıı..
    void OnBecameInvisible()
    {
        if (stomed == true)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
