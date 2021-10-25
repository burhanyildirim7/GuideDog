using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HumanCollectable : MonoBehaviour
{
    
  
    public HumanController humanController;

    private void Start()
    {
        humanController = GameObject.FindGameObjectWithTag("HumanController").gameObject.GetComponent<HumanController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            //humanController.CreateSegment();     

            humanController.AddHuman();
            humanController.sonEklenenInsan = false;
       
            Destroy(this.gameObject);

            GameManager.instance.AddPoint(10);

      

        }
       
    }

 
}
