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

    private int islemyapilacakSayi;

    public bool carpmaİslemi;
    public bool bolmeİslemi;
    public bool toplamaİslemi;


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
   
    }


    public void TotalHuman()
    {
        totalHuman = humanController.centerHumanList.Count + humanController.leftHumanList.Count + humanController.rightHumanList.Count;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(carpmaİslemi || toplamaİslemi)
            {
                for (int i = 0; i < (islemyapilacakSayi - totalHuman); i++)
                {

                    humanController.sonEklenenInsan = false;
                    humanController.AddHuman();

                }
            }
        
          if(bolmeİslemi)
            {
              

                 
                        int bolunecekIndexCenter = humanController.centerHumanList.Count / bolmeSayisi;
                        int bolunecekIndexLeft = humanController.leftHumanList.Count / bolmeSayisi;
                        int bolunecekIndexRight = humanController.rightHumanList.Count / bolmeSayisi;

                    if (humanController.centerHumanList.Count>0)
                        humanController.DeleteHuman(humanController.centerHumanList[bolunecekIndexCenter]);

                    if (humanController.leftHumanList.Count > 0)                      
                        humanController.DeleteHuman(humanController.leftHumanList[bolunecekIndexLeft]);

                    if (humanController.rightHumanList.Count > 0)
                        humanController.DeleteHuman(humanController.rightHumanList[bolunecekIndexRight]);



               
              
            }

        }
    }




}
