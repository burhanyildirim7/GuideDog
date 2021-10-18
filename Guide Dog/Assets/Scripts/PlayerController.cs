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
    private float _xMovement;
    private Animator _animator;

    

    public int humanCountWalk=15;
    public int humanCountRun = 25;

    public int humanWalkSpeed = 3;
    public int humanRunSpeed = 6;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _velocity = Vector3.zero;

    }

    private void PlayerForwardControl()
    {

        if (humanController.countHuman < humanCountWalk && humanController.countHuman < humanCountRun)
        {
            forwardVelocity = humanWalkSpeed;
            generator.TailWithSettings.TailAnimatorAmount = 1f;
            generator.TailWithSettings.WavingAxis.y = 0;
            generator.TailWithSettings.WavingAxis.x = 0;
            WalkHuman();
            generator.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0, 0), Time.deltaTime * 10);

        }
        else if (humanController.countHuman > humanCountWalk && humanController.countHuman < humanCountRun)
        {
            forwardVelocity = humanRunSpeed;
            generator.TailWithSettings.TailAnimatorAmount = 1f;
            generator.TailWithSettings.WavingAxis.y = 0;
            generator.TailWithSettings.WavingAxis.x = 0;
            generator.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0, 0), Time.deltaTime * 10);
            RunHuman();

        }
        else if (humanController.countHuman > humanCountRun && humanController.countHuman > humanCountWalk)
        {
            forwardVelocity = humanRunSpeed;
            generator.TailWithSettings.TailAnimatorAmount = 1f;
            generator.TailWithSettings.WavingAxis.y = 1;
            generator.TailWithSettings.WavingAxis.x = 1;
            generator.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(50f, 0, 0), Time.deltaTime * 10);

            RunHuman();
        }
    }

    private void WalkHuman()
    {
        foreach (var human in humanController.centerHumanList)
        {
            if (human != null)
                human.GetComponent<Animator>().SetBool("isRun", false);

        }
        foreach (var human in humanController.leftHumanList)
        {
            if (human != null)
                human.GetComponent<Animator>().SetBool("isRun", false);

        }
        foreach (var human in humanController.rightHumanList)
        {
            if (human != null)
                human.GetComponent<Animator>().SetBool("isRun", false);

        }
    }

    private void RunHuman()
    {
        foreach (var human in humanController.centerHumanList)
        {
            if (human != null)
                human.GetComponent<Animator>().SetBool("isRun", true);

        }
        foreach (var human in humanController.leftHumanList)
        {
            if(human!=null)
                human.GetComponent<Animator>().SetBool("isRun", true);

        }
        foreach (var human in humanController.rightHumanList)
        {
            if (human != null)
                human.GetComponent<Animator>().SetBool("isRun", true);

        }

    }

    private void FixedUpdate()
    {
        PlayerForwardControl();
        Run();
        InputHandling();
        MoveX();
        TouchHandling();
        _rigidbody.velocity = _velocity;
    }

    private void Run()
    {

        _velocity.z = forwardVelocity;
    }

    private void MoveX()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(_xMovement, transform.position.y, transform.position.z), Time.deltaTime * xSpeed);
    }


    void InputHandling()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (_xMovement == 0)
            {
                _xMovement = -3;
            }
            else if (_xMovement == 3)
            {
                _xMovement = 0;
            }


        } else if (Input.GetKeyDown(KeyCode.D))
        {
            if (_xMovement == 0)
            {
                _xMovement = 3;
            }else if(_xMovement == -3)
            {
                _xMovement = 0;
            }
        }
    }


    private Touch _sTouch;
    bool _hasSwiped = false;

    void TouchHandling()
    {
        foreach (Touch t in Input.touches)
        {
            if(t.phase == TouchPhase.Began)
            {
                _sTouch = t;
            }
            else if (t.phase ==TouchPhase.Moved && !_hasSwiped)
            {
                float Xswipe = _sTouch.position.x - t.position.x;
                float Yswipe = _sTouch.position.y - t.position.y;
                float Distance = Mathf.Sqrt((Xswipe * Xswipe)) + Mathf.Sqrt((Yswipe * Yswipe));
               
             
                if (Distance < 5f)
                {
                    if (Xswipe < 0)//Right
                    {
                        if(_xMovement == 0)
                        {
                            _xMovement = 3;
                        }else if(_xMovement == -3)
                        {
                            _xMovement = 0;

                        }
                    }else if (Xswipe>0)//left
                    {
                        if(_xMovement == 0)
                        {
                            _xMovement = -3;

                        }else if (_xMovement == 3)
                        {
                            _xMovement = 0;
                        }
                    }
                }

                _hasSwiped = true;
                
            }else if(t.phase == TouchPhase.Ended)
            {
                _sTouch = new Touch();
                _hasSwiped = false;
            }
        }
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Perde")
        {

        

        }
    }


}
