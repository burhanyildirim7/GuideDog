using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    private GameObject _player;
    private void OnTriggerEnter(Collider other)
    {
        //GameManager.instance.FinishLevel();
        //        GameManager.instance.StopGame();

        GameManager._oyunSonu = true;

        //GameObject.FindGameObjectWithTag("HumanController").GetComponent<HumanController>().DestroyAllHuman();

        _player = GameObject.FindGameObjectWithTag("Player");

        _player.transform.position = new Vector3(0, _player.transform.position.y, _player.transform.position.z);
        
    }
}
