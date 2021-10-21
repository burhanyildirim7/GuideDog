using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public HumanController humanController;
    private bool playerActive;



    private void Start()
    {
        humanController = GameObject.Find("HumanController").gameObject.GetComponent<HumanController>();
    }

    private void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.tag == "HumanPlayer" && !playerActive )
        {

            humanController.DeleteHuman(other.gameObject);
            

        }
        if (other.gameObject.tag == "Player")
        {
            playerActive = true;
            humanController.PlayerDeleteHuman();
            StartCoroutine(PlayerStatus());
            GameManager.instance.insanVarmi = true;
        }

        

    }

    IEnumerator PlayerStatus()
    {
        yield return new WaitForSeconds(3f);
        playerActive = false;
    }
}
