using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Kazanma : MonoBehaviour
{

    public static int toplamAltin;
    public Text AltinText;

    void Start()
    {
        toplamAltin = PlayerPrefs.GetInt("miktar");
        AltinText.text = toplamAltin + "";
    }

    //oyunu başlatma fonk.
    public void ReplayGame()
    {
        SceneManager.LoadScene("Level1");  // sahnenin index i alıp 1 artırıyor ve bir sonraki sahneye geçiş oluyor.
    }

    //oyundan çıkış yapma fonk.
    public void QuitGame()
    {
        Debug.Log("Oyundan çıkıldı..");  //editorde çalışmayacağındanbir log ile görelim..
        Application.Quit(); //fonksiyonu ile çıkış yapılacaktır..

    }
}

