using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private GameObject Player;

    Vector3 aradakiFark;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        aradakiFark = transform.position - Player.transform.position;

    }


    void Update()
    {
        if (GameManager._oyunSonuSevinme == false)
        {
            if (GameManager._oyunSonu == false)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x, Player.transform.position.y + aradakiFark.y, Player.transform.position.z + aradakiFark.z), Time.deltaTime * 5f);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(5, Player.transform.position.y + aradakiFark.y, Player.transform.position.z + aradakiFark.z), Time.deltaTime * 3f);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(30, -25, transform.rotation.z), 15f * Time.deltaTime);
            }
        }else
        {
            transform.LookAt(Player.transform.position, Vector3.up);
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, 6, Player.transform.position.z + 15), Time.deltaTime * 2f);
        }
       
      
        

    }

    public void CameraReset()
    {
        transform.rotation = Quaternion.Euler(30, 0, 0);
    }

 
}
