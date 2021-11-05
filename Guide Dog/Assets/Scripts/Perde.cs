using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perde : MonoBehaviour
{
    public HumanController humanController;
    public int totalHuman;
    public int carpmaSayisi;
    public int bolmeSayisi;
    public int toplamaSayisi;
    public int cikarmaSayisi;

    private int islemyapilacakSayi;

    public bool carpmaİslemi;
    public bool bolmeİslemi;
    public bool toplamaİslemi;
    public bool cikarmaIslemi;

    private void Update()
    {
        TotalHuman();
        Matematikİslemleri();
    }

    private void Matematikİslemleri()
    {
        if (carpmaİslemi)
        {
            islemyapilacakSayi = totalHuman * carpmaSayisi;
        }
   
        else if (toplamaİslemi)
        {
            islemyapilacakSayi = totalHuman + toplamaSayisi;
        }
      
    }

    private void Start()
    {
        humanController = GameObject.Find("HumanController").gameObject.GetComponent<HumanController>();
    }


    public void TotalHuman()
    {
        totalHuman = humanController._humanList.Count;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(carpmaİslemi || toplamaİslemi)
            {
                for (int i = 0; i < (islemyapilacakSayi - totalHuman); i++)
                {

                   // humanController.sonEklenenInsan = false;
                    humanController.AddHuman();

                }
            }
        
          if(bolmeİslemi)
            {
                            
                    int bolunecekIndexCenter = humanController._humanList.Count / bolmeSayisi;
                 

                    if (humanController._humanList.Count>0)
                        humanController.DeleteHuman(humanController._humanList[bolunecekIndexCenter]);

              
            }else if (cikarmaIslemi)
            {
                humanController.CikarmaIslemi(cikarmaSayisi);
            }

//            GameManager.instance.insanVarmi = true;

        }
    }

}
