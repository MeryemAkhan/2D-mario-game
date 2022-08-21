using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro; //TextMeshPro İçin
using UnityEngine;
using UnityEngine.Networking;  //veritabanı bağlantısı için 
using UnityEngine.UI;//UI objeleri için


public class RegisterSystem : MonoBehaviour
{

    public TMP_InputField kullaniciAdi_IF, sifre_IF, sifreTekrar_IF;
    public Toggle sozlesme;

    PanelKontrol pK_Script;

    

    void Start()
    {
        pK_Script = GetComponent<PanelKontrol>();
    }

 
    void Update()
    {
        
    }


    public void uyeligiOlustur_B() {
        if (kullaniciAdi_IF.text.Equals("") || sifre_IF.text.Equals("") || sifreTekrar_IF.text.Equals(""))
        {
                StartCoroutine(pK_Script.hataPanel("Boş BIRAKMAYINIZ!"));
          
        }
        else {

            if (sifre_IF.text.Equals(sifreTekrar_IF.text))
            {
                if (sozlesme.isOn)
                {
                    Debug.Log("Veritabanı Bağlantısı");
                    StartCoroutine(kayitOl());
                   
                }
                else
                {
                    StartCoroutine(pK_Script.hataPanel("Sözleşmeyi Kabul Ediniz!"));
                }
            }
            else
            {
                StartCoroutine(pK_Script.hataPanel("Şifreler Eşleşmiyor!"));
            }
        }
    }



    IEnumerator kayitOl()
    {
        WWWForm form = new WWWForm();
        form.AddField("unity", "kayitOlma");  //php de yazdığım sorguda unity kayıt olmayı bul diyorum.
        form.AddField("kullaniciAdi", kullaniciAdi_IF.text); //meryem yazdığımda text içine onu alıp php ye gönderecek
        form.AddField("sifre", sifre_IF.text);

        //istek yapacağımız uri verisi
        //buraya form daki bilgileri post ediyor.
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/Unity_DB/userRegister.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Sorgu Sonucu :" + www.downloadHandler.text);
                StartCoroutine(pK_Script.hataPanel(www.downloadHandler.text));
            }
        }
    }



}

	