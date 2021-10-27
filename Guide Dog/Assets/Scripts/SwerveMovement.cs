using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    private SwerveInputSystem _swerveInputSystem;
    [SerializeField] private float swerveSpeed = 0.5f;
  //  [SerializeField] private float _hareketSinirlandirmaSol = -4f;
//    [SerializeField] private float _hareketSinirlandirmaSag = 4f;

    //[SerializeField] private GameObject _getPoint;

    [SerializeField] private float _radius;

    Vector3 centerPosition;
    //[SerializeField] private float maxSwerveAmount = 1f;

    private void Awake()
    {
        _swerveInputSystem = GetComponent<SwerveInputSystem>();
    }

    private void Update()
    {

        if (GameManager._gameActive == true && GameManager._oyunSonu == false)
        {
            centerPosition = new Vector3(0, transform.position.y, transform.position.z);


            float swerveAmount = Time.deltaTime * swerveSpeed * _swerveInputSystem.MoveFactorX;
            //swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
            transform.Translate(swerveAmount, 0, 0);


            float distance = Vector3.Distance(transform.position, centerPosition);

            if (distance > _radius)
            {
                Vector3 fromOriginToObject = transform.position - centerPosition;
                fromOriginToObject *= _radius / distance;
                transform.position = centerPosition + fromOriginToObject;
            }
            else
            {

            }
        }
       
      
    }
}
