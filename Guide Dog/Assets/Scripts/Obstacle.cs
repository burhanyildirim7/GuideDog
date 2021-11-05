using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Obstacle : MonoBehaviour
{
    private HumanController humanController;
    private bool playerActive;

    private GameManager _gameManager;

    private void Start()
    {
        humanController = GameObject.Find("HumanController").GetComponent<HumanController>();
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.tag == "HumanPlayer" && !playerActive )
        {

            humanController.DeleteHuman(other.gameObject);

            NavMeshAgent agent = other.GetComponent<NavMeshAgent>();
            agent.enabled = false;

            if (humanController.countHuman == 0)
            {
                _gameManager.LoseGame();
            }



        }
        if (other.gameObject.tag == "Player")
        {
            playerActive = true;
            humanController.PlayerDeleteHuman();
            StartCoroutine(PlayerStatus());

            if (humanController.countHuman == 0)
            {
                _gameManager.LoseGame();
            }

            // GameManager.instance.insanVarmi = true;
        }


    }

    IEnumerator PlayerStatus()
    {
        yield return new WaitForSeconds(3f);
        playerActive = false;
    }
}
