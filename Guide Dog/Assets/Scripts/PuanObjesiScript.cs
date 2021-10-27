using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuanObjesiScript : MonoBehaviour
{
    [SerializeField] private HumanController humanController;

    [SerializeField] private GameObject _player;

    public static int _oyunSonuXDegeri;


    private void OyunuKazandi()
    {
        GameManager.instance.FinishLevel();

    }

    private void Update()
    {
        transform.position = _player.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.tag == "X1")
            {
                if (humanController.countHuman > 10)
                {
                    humanController.CikarmaIslemi(10);
                }
                else
                {
                _oyunSonuXDegeri = 1;
                _player.GetComponent<Animator>().SetBool("isWalk", false);
                _player.GetComponent<Animator>().SetBool("isRun", false);
                _player.GetComponent<Animator>().SetBool("isIdle", true);
                GameObject.FindGameObjectWithTag("HumanController").GetComponent<HumanController>().DestroyAllHuman();
                    GameManager._gameActive = false;
                    GameManager._oyunSonuSevinme = true;
                    Invoke("OyunuKazandi", 2.5f);
                }

            }
            else if (other.gameObject.tag == "X2")
            {
                if (humanController.countHuman > 10)
                {
                    humanController.CikarmaIslemi(10);
                }
                else
                {
                _oyunSonuXDegeri = 2;
                _player.GetComponent<Animator>().SetBool("isWalk", false);
                _player.GetComponent<Animator>().SetBool("isRun", false);
                _player.GetComponent<Animator>().SetBool("isIdle", true);
                GameObject.FindGameObjectWithTag("HumanController").GetComponent<HumanController>().DestroyAllHuman();
                    GameManager._gameActive = false;
                    GameManager._oyunSonuSevinme = true;
                    Invoke("OyunuKazandi", 2.5f);
                }
            }
            else if (other.gameObject.tag == "X3")
            {
                if (humanController.countHuman > 10)
                {
                    humanController.CikarmaIslemi(10);
                }
                else
                {
                _oyunSonuXDegeri = 3;
                _player.GetComponent<Animator>().SetBool("isWalk", false);
                _player.GetComponent<Animator>().SetBool("isRun", false);
                _player.GetComponent<Animator>().SetBool("isIdle", true);
                GameObject.FindGameObjectWithTag("HumanController").GetComponent<HumanController>().DestroyAllHuman();
                    GameManager._gameActive = false;
                    GameManager._oyunSonuSevinme = true;
                    Invoke("OyunuKazandi", 2.5f);
                }
            }
            else if (other.gameObject.tag == "X4")
            {
                if (humanController.countHuman > 10)
                {
                    humanController.CikarmaIslemi(10);
                }
                else
                {
                _oyunSonuXDegeri = 4;
                _player.GetComponent<Animator>().SetBool("isWalk", false);
                _player.GetComponent<Animator>().SetBool("isRun", false);
                _player.GetComponent<Animator>().SetBool("isIdle", true);
                GameObject.FindGameObjectWithTag("HumanController").GetComponent<HumanController>().DestroyAllHuman();
                    GameManager._gameActive = false;
                    GameManager._oyunSonuSevinme = true;
                    Invoke("OyunuKazandi", 2.5f);
                }
            }
            else if (other.gameObject.tag == "X5")
            {
                if (humanController.countHuman > 10)
                {
                    humanController.CikarmaIslemi(10);
                }
                else
                {
                _oyunSonuXDegeri = 5;
                _player.GetComponent<Animator>().SetBool("isWalk", false);
                _player.GetComponent<Animator>().SetBool("isRun", false);
                _player.GetComponent<Animator>().SetBool("isIdle", true);
                GameObject.FindGameObjectWithTag("HumanController").GetComponent<HumanController>().DestroyAllHuman();
                    GameManager._gameActive = false;
                    GameManager._oyunSonuSevinme = true;
                    Invoke("OyunuKazandi", 2.5f);
                }
            }
            else if (other.gameObject.tag == "X6")
            {
                if (humanController.countHuman > 10)
                {
                    humanController.CikarmaIslemi(10);
                }
                else
                {
                _oyunSonuXDegeri = 6;
                _player.GetComponent<Animator>().SetBool("isWalk", false);
                _player.GetComponent<Animator>().SetBool("isRun", false);
                _player.GetComponent<Animator>().SetBool("isIdle", true);
                GameObject.FindGameObjectWithTag("HumanController").GetComponent<HumanController>().DestroyAllHuman();
                    GameManager._gameActive = false;
                    GameManager._oyunSonuSevinme = true;
                    Invoke("OyunuKazandi", 2.5f);
                }
            }
            else if (other.gameObject.tag == "X7")
            {
                if (humanController.countHuman > 10)
                {
                    humanController.CikarmaIslemi(10);
                }
                else
                {
                _oyunSonuXDegeri = 7;
                _player.GetComponent<Animator>().SetBool("isWalk", false);
                _player.GetComponent<Animator>().SetBool("isRun", false);
                _player.GetComponent<Animator>().SetBool("isIdle", true);
                GameObject.FindGameObjectWithTag("HumanController").GetComponent<HumanController>().DestroyAllHuman();
                    GameManager._gameActive = false;
                    GameManager._oyunSonuSevinme = true;
                    Invoke("OyunuKazandi", 2.5f);
                }
            }
            else if (other.gameObject.tag == "X8")
            {
                if (humanController.countHuman > 10)
                {
                    humanController.CikarmaIslemi(10);
                }
                else
                {
                _oyunSonuXDegeri = 8;
                _player.GetComponent<Animator>().SetBool("isWalk", false);
                _player.GetComponent<Animator>().SetBool("isRun", false);
                _player.GetComponent<Animator>().SetBool("isIdle", true);
                GameObject.FindGameObjectWithTag("HumanController").GetComponent<HumanController>().DestroyAllHuman();
                    GameManager._gameActive = false;
                    GameManager._oyunSonuSevinme = true;
                    Invoke("OyunuKazandi", 2.5f);
                }
            }
            else if (other.gameObject.tag == "X9")
            {
                if (humanController.countHuman > 10)
                {
                    humanController.CikarmaIslemi(10);
                }
                else
                {
                _oyunSonuXDegeri = 9;
                _player.GetComponent<Animator>().SetBool("isWalk", false);
                _player.GetComponent<Animator>().SetBool("isRun", false);
                _player.GetComponent<Animator>().SetBool("isIdle", true);
                GameObject.FindGameObjectWithTag("HumanController").GetComponent<HumanController>().DestroyAllHuman();
                    GameManager._gameActive = false;
                    GameManager._oyunSonuSevinme = true;
                    Invoke("OyunuKazandi", 2.5f);
                }
            }
            else if (other.gameObject.tag == "X10")
            {
                if (humanController.countHuman > 10)
                {
                    humanController.CikarmaIslemi(10);
                }
                else
                {
                _oyunSonuXDegeri = 10;
                _player.GetComponent<Animator>().SetBool("isWalk", false);
                _player.GetComponent<Animator>().SetBool("isRun", false);
                _player.GetComponent<Animator>().SetBool("isIdle", true);
                GameObject.FindGameObjectWithTag("HumanController").GetComponent<HumanController>().DestroyAllHuman();
                    GameManager._gameActive = false;
                    GameManager._oyunSonuSevinme = true;
                    Invoke("OyunuKazandi", 2.5f);
                }
            }
        }
    
}
