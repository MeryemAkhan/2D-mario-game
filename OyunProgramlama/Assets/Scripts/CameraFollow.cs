using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player; //bir transform aldım player adında..

    //Serialize Field olarak değişkenler tanımladım
    //unity içerisinde değiştirilebilir alanlar eklemiş oldum.

    [SerializeField]
    private float smoothX;
    [SerializeField]
    private float smoothY;

    //kameranın gördüğü açıyı sınırlandırmak için sınırlamalar
    [SerializeField]
    private float minX;
    [SerializeField]
    private float minY;
    [SerializeField]
    private float maxX;
    [SerializeField]
    private float maxY;


    private void Start()
    {
        //player imiza bir GameObject atayalım..
        player = GameObject.Find("Mario").transform;  //player objesinin tansformunu aldık..
    }



    // kameranın gerçek zamanlı konumlandırması lateupdate içerisinde yazılır..
    //update içine yazılırsa işlemcinin hızına göre bazı kesik hareketler olur.
    void LateUpdate()
    {
        float posX = Mathf.MoveTowards(transform.position.x, player.position.x, smoothX);  //position x adında posx, matematik kütüphanesi olan Mathf kullandım. 
        float posY = Mathf.MoveTowards(transform.position.y, player.position.y, smoothY);
        //Yumuşak bir geçiiş olması için MoveTowardsAngle yerine MoveTowards kullandım.

        //kameranın z ekseni için de vector3 kullandım..
        //sınırlama için Mathf.Clamp fonk ile posx deki ve pos y deki min max değerleri alırız..
        //kameranın açısını kontrol eden şey derinlik yani z pozisyonudur. Ondan dolayı z pozisyonun transformunu aldık
        transform.position = new Vector3(Mathf.Clamp (posX,minX,maxX ),Mathf.Clamp(posY, minY, maxY), transform.position.z);
    }
}
