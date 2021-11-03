using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class adamSayisiCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = FindObjectOfType<HumanController>().totalHumanList.Count.ToString();
    }
}
