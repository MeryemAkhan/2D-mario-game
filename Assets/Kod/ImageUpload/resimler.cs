using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class resimler : MonoBehaviour
{

    public GameObject resimOrnek;
    public Transform icPanel;
  
    public void resimCagrisi() {
        StartCoroutine(resimleri_Getir());
    }

    public string[] resimUris;
    IEnumerator resimleri_Getir()
    {
        WWWForm form = new WWWForm();
        form.AddField("unity", "resimleriGetir");

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/unity_DB/image.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);  //php den dönen sonuç
                resimUris = www.downloadHandler.text.Split(';');
                StartCoroutine(DownloadImage(resimUris));
            }
        }
    }


    IEnumerator DownloadImage(string[] uris)
    {
        for (int i = 0; i < uris.Length-1; i++) {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(uris[i]);
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
            else
            {
                GameObject ornekClone = Instantiate(resimOrnek);
                ornekClone.GetComponent<RawImage>().texture=((DownloadHandlerTexture)request.downloadHandler).texture;
                ornekClone.transform.SetParent(icPanel);
                ornekClone.transform.localScale = new Vector3(1, 1, 1);
            }

        }

        
    }
}




