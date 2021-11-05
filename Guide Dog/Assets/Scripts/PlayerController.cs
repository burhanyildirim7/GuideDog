using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   // public TailDemo_SegmentedTailGenerator generator;

    [SerializeField]
    public float forwardVelocity = 3;
    public Vector3 _velocity;
    private Rigidbody _rigidbody;
    public HumanController humanController;

    public float xSpeed = 10;
    //    private float _xMovement;
    private Animator _animator;

    private float _speed;

    public int humanCountWalk = 15;
    public int humanCountRun = 30;

    public int humanWalkSpeed = 5;
    public int humanRunSpeed = 7;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _velocity = Vector3.zero;



    }


    private void FixedUpdate()
    {
        if (GameManager._gameActive == true)
        {

            //Run();
            //InputHandling();
            // MoveX();
            //TouchHandling();
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
            // _rigidbody.velocity = _velocity;
        }

    }
    private void Update()
    {
        if (GameManager._gameActive == true)
        {
            PlayerForwardControl();
        }

    }


    private void PlayerForwardControl()
    {
        if (GameManager._oyunSonu == false)
        {
            if (humanController.countHuman < humanCountWalk && humanController.countHuman < humanCountRun)
            {
                _speed = humanWalkSpeed;
                DogWalk();
                WalkHuman();

            }
            else if (humanController.countHuman > humanCountWalk && humanController.countHuman < humanCountRun)
            {
                _speed = humanRunSpeed;
                DogRun();
                RunHuman();

            }
            else if (humanController.countHuman > humanCountRun && humanController.countHuman > humanCountWalk)
            {
                _speed = humanRunSpeed;
                DogRun();
                RunHuman(); // bu yoktu
                //FlyHuman(); // bu açıktı
            }
        }
        else
        {
            _speed = 7;
            DogRun();
            RunHuman();
        }

    }

    private void WalkHuman()
    {

        foreach (var human in humanController._humanList)
        {
            if (human != null)
            {
                human.GetComponent<Animator>().SetBool("isFly", false);
                human.GetComponent<Animator>().SetBool("isRun", false);
                human.GetComponent<Animator>().SetBool("isWalk", true);
            }

        }
    }

    private void RunHuman()
    {

        foreach (var human in humanController._humanList)
        {
            if (human != null)
            {
                human.GetComponent<Animator>().SetBool("isFly", false);
                human.GetComponent<Animator>().SetBool("isWalk", false);
                human.GetComponent<Animator>().SetBool("isRun", true);
            }

        }

    }

    private void FlyHuman()
    {

        foreach (var human in humanController._humanList)
        {
            if (human != null)
            {
                human.GetComponent<Animator>().SetBool("isWalk", false);
                human.GetComponent<Animator>().SetBool("isRun", false);
                human.GetComponent<Animator>().SetBool("isFly", true);
            }

        }

    }


    public void DogIdle()
    {
        GameObject.FindGameObjectWithTag("Dog").GetComponent<Animator>().SetBool("isWalk", false);
        GameObject.FindGameObjectWithTag("Dog").GetComponent<Animator>().SetBool("isRun", false);
        GameObject.FindGameObjectWithTag("Dog").GetComponent<Animator>().SetBool("isIdle", true);
    }

    public void DogWalk()
    {
        GameObject.FindGameObjectWithTag("Dog").GetComponent<Animator>().SetBool("isIdle", false);
        GameObject.FindGameObjectWithTag("Dog").GetComponent<Animator>().SetBool("isRun", false);
        GameObject.FindGameObjectWithTag("Dog").GetComponent<Animator>().SetBool("isWalk", true);
    }

    private void DogRun()
    {
        GameObject.FindGameObjectWithTag("Dog").GetComponent<Animator>().SetBool("isWalk", false);
        GameObject.FindGameObjectWithTag("Dog").GetComponent<Animator>().SetBool("isIdle", false);
        GameObject.FindGameObjectWithTag("Dog").GetComponent<Animator>().SetBool("isRun", true);
    }


    private void Run()
    {

        _velocity.z = forwardVelocity;
    }

    public void PlayerStartPosition()
    {
        transform.position = new Vector3(0, 0.5f, 0);
        //        _xMovement = 0;
    }
    /*
    private void OyunuKazandi()
    {
        GameManager.instance.FinishLevel();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "X1" && gameObject.tag != "HumanPlayer")
        {
            if (humanController.countHuman > 5)
            {
                humanController.CikarmaIslemi(5);
            }
            else
            {
                GameObject.FindGameObjectWithTag("HumanController").GetComponent<HumanController>().DestroyAllHuman();
                GameManager._gameActive = false;
                GameManager._oyunSonuSevinme = true;
                Invoke("OyunuKazandi", 2.5f);
            }

        }
        else if (other.gameObject.tag == "X2" && gameObject.tag != "HumanPlayer")
        {
            if (humanController.countHuman > 5)
            {
                humanController.CikarmaIslemi(5);
            }
            else
            {
                GameObject.FindGameObjectWithTag("HumanController").GetComponent<HumanController>().DestroyAllHuman();
                GameManager._gameActive = false;
                GameManager._oyunSonuSevinme = true;
                Invoke("OyunuKazandi", 2.5f);
            }
        }
        else if (other.gameObject.tag == "X3" && gameObject.tag != "HumanPlayer")
        {
            if (humanController.countHuman > 5)
            {
                humanController.CikarmaIslemi(5);
            }
            else
            {
                GameObject.FindGameObjectWithTag("HumanController").GetComponent<HumanController>().DestroyAllHuman();
                GameManager._gameActive = false;
                GameManager._oyunSonuSevinme = true;
                Invoke("OyunuKazandi", 2.5f);
            }
        }
        else if (other.gameObject.tag == "X4" && gameObject.tag != "HumanPlayer")
        {
            if (humanController.countHuman > 5)
            {
                humanController.CikarmaIslemi(5);
            }
            else
            {
                GameObject.FindGameObjectWithTag("HumanController").GetComponent<HumanController>().DestroyAllHuman();
                GameManager._gameActive = false;
                GameManager._oyunSonuSevinme = true;
                Invoke("OyunuKazandi", 2.5f);
            }
        }
        else if (other.gameObject.tag == "X5" && gameObject.tag != "HumanPlayer")
        {
            if (humanController.countHuman > 5)
            {
                humanController.CikarmaIslemi(5);
            }
            else
            {
                GameObject.FindGameObjectWithTag("HumanController").GetComponent<HumanController>().DestroyAllHuman();
                GameManager._gameActive = false;
                GameManager._oyunSonuSevinme = true;
                Invoke("OyunuKazandi", 2.5f);
            }
        }
        else if (other.gameObject.tag == "X6" && gameObject.tag != "HumanPlayer")
        {
            if (humanController.countHuman > 5)
            {
                humanController.CikarmaIslemi(5);
            }
            else
            {
                GameObject.FindGameObjectWithTag("HumanController").GetComponent<HumanController>().DestroyAllHuman();
                GameManager._gameActive = false;
                GameManager._oyunSonuSevinme = true;
                Invoke("OyunuKazandi", 2.5f);
            }
        }
        else if (other.gameObject.tag == "X7" && gameObject.tag != "HumanPlayer")
        {
            if (humanController.countHuman > 5)
            {
                humanController.CikarmaIslemi(5);
            }
            else
            {
                GameObject.FindGameObjectWithTag("HumanController").GetComponent<HumanController>().DestroyAllHuman();
                GameManager._gameActive = false;
                GameManager._oyunSonuSevinme = true;
                Invoke("OyunuKazandi", 2.5f);
            }
        }
        else if (other.gameObject.tag == "X8" && gameObject.tag != "HumanPlayer")
        {
            if (humanController.countHuman > 5)
            {
                humanController.CikarmaIslemi(5);
            }
            else
            {
                GameObject.FindGameObjectWithTag("HumanController").GetComponent<HumanController>().DestroyAllHuman();
                GameManager._gameActive = false;
                GameManager._oyunSonuSevinme = true;
                Invoke("OyunuKazandi", 2.5f);
            }
        }
        else if (other.gameObject.tag == "X9" && gameObject.tag != "HumanPlayer")
        {
            if (humanController.countHuman > 5)
            {
                humanController.CikarmaIslemi(5);
            }
            else
            {
                GameObject.FindGameObjectWithTag("HumanController").GetComponent<HumanController>().DestroyAllHuman();
                GameManager._gameActive = false;
                GameManager._oyunSonuSevinme = true;
                Invoke("OyunuKazandi", 2.5f);
            }
        }
        else if (other.gameObject.tag == "X10" && gameObject.tag != "HumanPlayer")
        {
            if (humanController.countHuman > 5)
            {
                humanController.CikarmaIslemi(5);
            }
            else
            {
                GameObject.FindGameObjectWithTag("HumanController").GetComponent<HumanController>().DestroyAllHuman();
                GameManager._gameActive = false;
                GameManager._oyunSonuSevinme = true;
                Invoke("OyunuKazandi", 2.5f);
            }
        }
    }
    */



}
