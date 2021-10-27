using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatsayilardakiScript : MonoBehaviour
{
    [SerializeField] private GameObject _insanPaketi;
    void Start()
    {
        _insanPaketi.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PuanObjesi")
        {
            _insanPaketi.SetActive(true);
        }
    }
}
