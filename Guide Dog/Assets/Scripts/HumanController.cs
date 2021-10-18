using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public TailDemo_CuttingController controller;
    public TailDemo_SegmentedTailGenerator tailDemo_SegmentedTailGenerator;

    public List<GameObject> centerHumanList;
    public List<GameObject> leftHumanList;
    public List<GameObject> rightHumanList;

    //public List<GameObject> segmentList;

    public GameObject prefab;

    public List<Vector3> humanVectors;

    public bool sonEklenenInsan;

    public int countHuman;

    public void Update()
    {
        ClearLists();
        countHuman = centerHumanList.Count + leftHumanList.Count + rightHumanList.Count;
    }

    public void AddHuman()
    {

        if (centerHumanList != null)
        {

            for (int i = 0; i <= centerHumanList.Count; i++)
            {
                //Hepsi boş
                if (centerHumanList.Count == i && leftHumanList.Count == i && rightHumanList.Count == i && !sonEklenenInsan)
                {
                    //SegmentArttır(i);
                    CreateHumanPrefab(i, humanVectors[0], 0);
                    sonEklenenInsan = true;
                }
                //centerda var, left ve right boş
                else if (centerHumanList.Count > i && leftHumanList.Count < i+1 && rightHumanList.Count < i+1 && !sonEklenenInsan)
                {
                    CreateHumanPrefab(i, humanVectors[1], 1);
                    sonEklenenInsan = true;
                }   //center left var, right boş
                else if (centerHumanList.Count > i && leftHumanList.Count > i && rightHumanList.Count < i+1 && !sonEklenenInsan)
                {
                    CreateHumanPrefab(i, humanVectors[2], 2);
                    sonEklenenInsan = true;

                }   //center right var, left boş
                else if (centerHumanList.Count > i && rightHumanList.Count > i && leftHumanList.Count < i+1 && !sonEklenenInsan)
                {
                    CreateHumanPrefab(i, humanVectors[1], 1);
                    sonEklenenInsan = true;
                }   //center left boş, right var
                else if (centerHumanList.Count < i+1 && leftHumanList.Count < i+1 && rightHumanList.Count > i && !sonEklenenInsan)
                {
                    CreateHumanPrefab(i, humanVectors[0], 0);
                    sonEklenenInsan = true;
                }   //left var, center right boş
                else if (leftHumanList.Count > i && centerHumanList.Count <i+ 1 && rightHumanList.Count < i+1 && !sonEklenenInsan)
                {
                    CreateHumanPrefab(i, humanVectors[0], 0);
                    sonEklenenInsan = true;
                }
            }

        }

    }

    private void CreateHumanPrefab(int i,Vector3 humanVector,int position)
    {
        GameObject human = Instantiate(prefab, humanVector, Quaternion.Euler(0, 0, 0));
        human.transform.parent = tailDemo_SegmentedTailGenerator.tailSegments[i + 2].transform;
        human.transform.localPosition = humanVector;
        human.AddComponent<BoxCollider>();

        human.transform.localRotation = Quaternion.Euler(0, 0, 0);
     

        if (position == 0)
        {
            centerHumanList.Add(human);
        }else if (position==1)
        {
            leftHumanList.Add(human);
        }
        else if(position==2)
        {
            rightHumanList.Add(human);
        }   

    }

    public void DeleteHuman(GameObject deleteHuman)
    {   

        for (int i = 0; i < rightHumanList.Count; i++)
        {
            if (deleteHuman == rightHumanList[i])
            {         
                for (int j = i; j < rightHumanList.Count; j++)
                {
                    rightHumanList[j].transform.parent = null;
          
                    Destroy(rightHumanList[j],2f);             
                }

    
            }
        
        }
        for (int i = 0; i < leftHumanList.Count; i++)
        {
            if (deleteHuman == leftHumanList[i])
            {
                for (int j = i; j < leftHumanList.Count; j++)
                {
                    leftHumanList[j].transform.parent = null;
               
                    Destroy(leftHumanList[j],2f);     
                }

            }

        }
        for (int i = 0; i < centerHumanList.Count; i++)
        {
            if (deleteHuman == centerHumanList[i])
            {
                for (int j = i; j < centerHumanList.Count; j++)
                {
                    centerHumanList[j].transform.parent = null;
             
                    Destroy(centerHumanList[j],2f);
                }

            }

        }

    }

  
    public void ClearLists()
    {
        for (int i = 0; i < centerHumanList.Count; i++)
        {
            if (centerHumanList[i] == null)
            {
          
                centerHumanList.RemoveAt(i);
            }
        }
        for (int i = 0; i < leftHumanList.Count; i++)
        {
            if (leftHumanList[i] == null)
            {
             
                leftHumanList.RemoveAt(i);
            }
        }
        for (int i = 0; i < rightHumanList.Count; i++)
        {
            if (rightHumanList[i] == null)
            {

            
                rightHumanList.RemoveAt(i);
            }
        }

    }
  




}


