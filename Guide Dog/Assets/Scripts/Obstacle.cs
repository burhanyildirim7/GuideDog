using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public HumanController humanController;
    private bool playerActive;
    
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
        }

    }
}
