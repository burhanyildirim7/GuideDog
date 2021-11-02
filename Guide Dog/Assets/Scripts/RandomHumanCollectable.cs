using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomHumanCollectable : MonoBehaviour
{
   
    void Start()
    {
        int randomsayi = Random.Range(0, transform.childCount);
        GameObject human = this.gameObject.transform.GetChild(randomsayi).gameObject;
        human.SetActive(true);
    }

    
}
