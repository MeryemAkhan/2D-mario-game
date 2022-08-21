using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Kaybetme : MonoBehaviour
{
    public static int toplamAltin;
    public Text AltinText;

    void Start()
    {
        toplamAltin = PlayerPrefs.GetInt("miktar");   //PlayerPrefs.GetInt ile kaydettiğimiz integer değeri hangi anahtar ismi ile kayıt ettiysek onunla çekiyoruz.
        AltinText.text = toplamAltin + "";
    }

    //oyunu başlatma fonk.
    public void ReplayGame()
    {
        SceneManager.LoadScene("Level1");  // sahne adı ile  bir sonraki sahneye geçiş oluyor.
    }

    //oyundan çıkış yapma fonk.
    public void QuitGame()
    {
        Debug.Log("Oyundan çıkıldı..");  //editorde çalışmayacağından bir log ile görelim..
        Application.Quit(); //fonksiyonu ile çıkış yapılacaktır..

    }
}
