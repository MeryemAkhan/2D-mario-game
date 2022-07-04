using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelKontrol : MonoBehaviour
{
    private Animator animator;
    private Animator hataAnimator;

    public TextMeshProUGUI hata_TMP;

    void Start()
    {
        animator = GameObject.Find("Paneller").GetComponent<Animator>();
        hataAnimator= GameObject.Find("Hata_P").GetComponent<Animator>();
    }

    public void Kayitol_B() {
        animator.SetBool("KayitOL", true);
    }
    public void KayitP_Geri_B() {
        animator.SetBool("KayitOL", false);
    }

    public IEnumerator hataPanel(string hataText) {
        hata_TMP.SetText(hataText);
        hataAnimator.SetBool("HataDurumu", true);
        yield return new WaitForSeconds(1.5f);
        hataAnimator.SetBool("HataDurumu", false);
    }


}
