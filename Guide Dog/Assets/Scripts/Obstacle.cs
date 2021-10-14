using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public HumanController humanController;
    public int azalmaDegeri=5;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player" )
        {

            //humanController.DeleteHuman(azalmaDegeri);


        }

    }
}
