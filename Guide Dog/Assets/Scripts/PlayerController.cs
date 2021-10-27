using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public TailDemo_SegmentedTailGenerator generator;

    [SerializeField]
    public float forwardVelocity = 3;
    public Vector3 _velocity;
    private Rigidbody _rigidbody;
    public HumanController humanController;

    public float xSpeed = 10;
//    private float _xMovement;
    private Animator _animator;

    private float _speed;

    public int humanCountWalk=15;
    public int humanCountRun = 25;

    public int humanWalkSpeed = 4;
    public int humanRunSpeed = 6;

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
            PlayerForwardControl();
            //Run();
            //InputHandling();
            // MoveX();
            //TouchHandling();
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
           // _rigidbody.velocity = _velocity;
        }
       
    }


    private void PlayerForwardControl()
    {

        if (humanController.countHuman < humanCountWalk && humanController.countHuman < humanCountRun)
        {
            _speed = humanWalkSpeed;
            generator.TailWithSettings.TailAnimatorAmount = 1f;
            generator.TailWithSettings.WavingAxis.y = 0;
            generator.TailWithSettings.WavingAxis.x = 0;
            DogWalk();
            WalkHuman();
            generator.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0, 0), Time.deltaTime * 10);

        }
        else if (humanController.countHuman > humanCountWalk && humanController.countHuman < humanCountRun)
        {
            _speed = humanRunSpeed;
            generator.TailWithSettings.TailAnimatorAmount = 1f;
            generator.TailWithSettings.WavingAxis.y = 0;
            generator.TailWithSettings.WavingAxis.x = 0;
            generator.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0, 0), Time.deltaTime * 10);
            DogRun();
            RunHuman();

        }
        else if (humanController.countHuman > humanCountRun && humanController.countHuman > humanCountWalk)
        {
            _speed = humanRunSpeed;
            generator.TailWithSettings.TailAnimatorAmount = 1f;
            generator.TailWithSettings.WavingAxis.y = 1;
            generator.TailWithSettings.WavingAxis.x = 1;
            generator.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(50f, 0, 0), Time.deltaTime * 10);
            DogRun();
            FlyHuman();
        }
    }

    private void WalkHuman()
    {
        foreach (var human in humanController.centerHumanList)
        {
            if (human != null)
            {
                human.GetComponent<Animator>().SetBool("isFly", false);
                human.GetComponent<Animator>().SetBool("isRun", false);
                human.GetComponent<Animator>().SetBool("isWalk", true);
            }

        }
        foreach (var human in humanController.leftHumanList)
        {
            if (human != null)
            {
                human.GetComponent<Animator>().SetBool("isFly", false);
                human.GetComponent<Animator>().SetBool("isRun", false);
                human.GetComponent<Animator>().SetBool("isWalk", true);
            }

        }
        foreach (var human in humanController.rightHumanList)
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
        foreach (var human in humanController.centerHumanList)
        {
            if (human != null)
            {
                human.GetComponent<Animator>().SetBool("isFly", false);
                human.GetComponent<Animator>().SetBool("isWalk", false);
                human.GetComponent<Animator>().SetBool("isRun", true);
            }
                

        }
        foreach (var human in humanController.leftHumanList)
        {
            if (human != null)
            {
                human.GetComponent<Animator>().SetBool("isFly", false);
                human.GetComponent<Animator>().SetBool("isWalk", false);
                human.GetComponent<Animator>().SetBool("isRun", true);
            }

        }
        foreach (var human in humanController.rightHumanList)
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
        foreach (var human in humanController.centerHumanList)
        {
            if (human != null)
            {
                human.GetComponent<Animator>().SetBool("isWalk", false);
                human.GetComponent<Animator>().SetBool("isRun", false);
                human.GetComponent<Animator>().SetBool("isFly", true);
            }

        }
        foreach (var human in humanController.leftHumanList)
        {
            if (human != null)
            {
                human.GetComponent<Animator>().SetBool("isWalk", false);
                human.GetComponent<Animator>().SetBool("isRun", false);
                human.GetComponent<Animator>().SetBool("isFly", true);
            }

        }
        foreach (var human in humanController.rightHumanList)
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
