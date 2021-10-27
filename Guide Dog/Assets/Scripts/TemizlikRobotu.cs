using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemizlikRobotu : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, 0, _player.transform.position.z - 15);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "HumanPlayer")
        {
            Destroy(other.gameObject);
        }
    }
}
