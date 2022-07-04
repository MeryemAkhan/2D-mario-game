using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHp : MonoBehaviour
{
    //oyuncu yardımı
    int hP = 2;
    float timer;
    bool invincible = false;
    Material mWhite;
    Material mDefault;
    SpriteRenderer sRend;

    void Start()
    {
        sRend = GetComponent<SpriteRenderer>();
        mDefault = sRend.material;
        mWhite = Resources.Load("mWhite", typeof(Material)) as Material;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            invincible = false;
        }

        if (hP <= 0)
        {
            Time.timeScale = 0;
        }
    }

    //oyuncunun düşmanla çarpışıp çarpışmadığını kontrol ederizz..
    void OnCollisionEnter2D(Collision2D collision)
    {
        //carptığı nesnenin tag i enemy isee
        if (collision.collider.CompareTag("Enemy"))
        {
            if (hP == 2)
            {
                Resize();

            }

            --hP; //her çarptığında hp değeri birer birer azalır..
        }
        if (collision.collider.CompareTag("enemy1"))
        {
            string sonraki = "Kaybetme";
            SceneManager.LoadScene(sonraki);
        }
    }


    //player nesnesinin düşmana değdiğinde transform bileşeninden localscale ini vector3 ile değiştiriyoruz.
    //
    void Resize()
    {
        gameObject.transform.localScale -= new Vector3(0, 0.5f, 0);
        StartCoroutine("Flash");
        InvinciblePeriod();

    }

    void InvinciblePeriod()
    {
        timer = 1;
        if (timer > 0)
        {
            invincible = false;
        }
    }


    IEnumerator Flash()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.25f);
            sRend.material = mWhite;
            Invoke("ResetMaterial", 0.15f);

        }
    }

    void ResetMaterial()
    {
        sRend.material = mDefault;
    }

}
