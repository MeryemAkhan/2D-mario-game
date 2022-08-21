using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //oyunu başlatma fonk.
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);  // sahnenin index i alıp 1 artırıyor ve bir sonraki sahneye geçiş oluyor.
    }

    //oyundan çıkış yapma fonk.
    public void QuitGame()
    {
        Debug.Log("Oyundan çıkıldı..");  //editorde çalışmayacağındanbir log ile görelim..
        Application.Quit(); //fonksiyonu ile çıkış yapılacaktır..

    }
    //menu sahnesinegeçiş..
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("TanitimSahnesi");  //sadece menuye gitmesi için bu şekilde geçişi yazdım..
    }
}
