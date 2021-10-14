using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public int countHuman;
    public Vector3[] kuyruktakiInsan;
    public TailDemo_CuttingController controller;
    public TailDemo_SegmentedTailGenerator tailDemo_SegmentedTailGenerator;
    public GameObject prefab;
    public bool isInstantiate;


    public List<GameObject> tailSegments;

    //public GameObject[] humanInstantiate;
    public List<GameObject> humanInstantiate;

    public int toplanacakInsanSayisi;

    private void Start()
    {
        tailSegments.Add(tailDemo_SegmentedTailGenerator.tailSegments[0].transform.gameObject);
        tailSegments.Add(tailDemo_SegmentedTailGenerator.tailSegments[1].transform.gameObject);
        
    }

    private void Update()
    {
        //humanInstantiate = GameObject.FindGameObjectsWithTag("HumanPlayer");
        //humanInstantiate.AddRange(GameObject.FindGameObjectsWithTag("HumanPlayer"));
    }

    public void TailKaydetme(int index)
    {                                                           
         tailSegments.Add(tailDemo_SegmentedTailGenerator.tailSegments[index].transform.gameObject);
    }

    //public void TailSilme(int index)
    //{
    //    tailSegments.Remove(tailDemo_SegmentedTailGenerator.tailSegments[index].transform.gameObject);
    //}

    public void StartSegment()
    {
        countHuman++;

        for (int i = 1; i <= toplanacakInsanSayisi; i = i + 3)
        {
            if (i == countHuman)
            {
                controller.slider.value++;
                TailKaydetme(tailSegments.Count);
       
            }
        }
        StartHuman();
    }

    private void StartHuman()
    {
        for (int i = 1; i <= toplanacakInsanSayisi; i++)
        {
            if (i == countHuman)
            {

                GameObject human = Instantiate(prefab, tailSegments[tailSegments.Count-1].transform.position, Quaternion.identity);
               
                human.transform.parent = tailSegments[tailSegments.Count-1].transform;

                human.transform.localPosition = kuyruktakiInsan[i-1];
                                        
            }
          
        }
    }

    //public void DeleteHuman(int azalmaDegeri)
    //{
    //    //countHuman = countHuman - azalmaDegeri;

    //    //if (countHuman < 0) countHuman = 0;

    //    //for (int i = humanInstantiate.Length - 1; i >=countHuman ; i--)
    //    //{
    //    //    //Debug.Log(i);
    //    //    Destroy(humanInstantiate[i].gameObject);
    //    //}
    //    ////DeleteSegment();

    //}

    //private void DeleteSegment()
    //{
    //    for (int i = tailSegments.Count; i >= 1; i = i - 3)
    //    {
    //        Debug.Log("counthuman"+countHuman);
    //        Debug.Log(i);
    //        //Debug.Log("counthuman"+countHuman);
    //        if (i <= countHuman|| countHuman == 0)
    //        {
          
    //            controller.slider.value--;
    //            //tailSegments.RemoveAt(i);
    //            //TailSilme(tailSegments.Count);
    //        }


    //    }
    //}
}
