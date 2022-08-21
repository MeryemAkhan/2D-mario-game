using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UploadImage : MonoBehaviour
{
    Texture2D texture2d=null;
    public RawImage raw_image;
    public Image Image;

    void Start()
    {
        texture2d = new Texture2D(2,2);     
    }

    byte[] fileContent;
    public void dosyaSec()//DOSYA SEÇME FONSİYONU
    {
        string path = EditorUtility.OpenFilePanel("Bir Resim Seçiniz!", "", "png");
        if (path.Length != 0)
        {
            fileContent = File.ReadAllBytes(path);
            texture2d.LoadImage(fileContent);
          

            raw_image.texture = texture2d;
            Image.sprite =Sprite.Create(texture2d,new Rect(0,0,texture2d.width,texture2d.height),new Vector2(.5f,.5f));
        }
    }

    public void gonder()//GÖNDER BUTONU FONKSİYONU
    {
        StartCoroutine(DosyaYukle(fileContent));
    }

      IEnumerator DosyaYukle(byte[] bytes)
      {
          WWWForm form = new WWWForm();
          form.AddField("unity", "image");
       
          form.AddBinaryData("uploaded_file", bytes, "myImage.png", "image/png");
      
          using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/unity_DB/image.php", form))
          {
              yield return www.SendWebRequest();

              if (www.isNetworkError || www.isHttpError)
              {
                  Debug.Log(www.error);
              }
              else
              {
                  Debug.Log(www.downloadHandler.text); //yükleme basarili
              }
          }
      }

    public void indir_B()
    {
        StartCoroutine(DownloadImage("http://localhost/Unity_DB/Uye_Resimleri/resim1600784515953.png"));
    }
    IEnumerator DownloadImage(String uri)
    {   

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(uri);
        yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
                Debug.Log(request.error);
            else {
            
            raw_image.texture= ((DownloadHandlerTexture)request.downloadHandler).texture;          
            }                 
        }      
    }
