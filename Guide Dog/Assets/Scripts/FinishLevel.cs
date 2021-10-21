using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.FinishLevel();
        GameManager.instance.StopGame();
        
    }
}
