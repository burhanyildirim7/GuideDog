using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public HumanController humanController;
    
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "HumanPlayer" )
        {

            humanController.DeleteHuman(other.gameObject);
            

        }

    }
}
