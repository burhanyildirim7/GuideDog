using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    // public TailDemo_CuttingController controller;
    // public TailDemo_SegmentedTailGenerator tailDemo_SegmentedTailGenerator;

    public List<GameObject> _humanList;

    [SerializeField] private GameObject _humanSpawnPoint;

    // public List<GameObject> leftHumanList;
    // public List<GameObject> rightHumanList;

    // public List<GameObject> totalHumanList;

    public List<GameObject> _prefabs = new List<GameObject>();

    //public List<Vector3> humanVectors;

    //public bool sonEklenenInsan;

    public int countHuman;

    public void Update()
    {
        ClearLists();
        countHuman = _humanList.Count;

    }

    public void AddHuman()
    {

        CreateHumanPrefab();
    }

    private void CreateHumanPrefab()
    {
        int randomsayi = Random.Range(0, _prefabs.Count);
        GameObject human = Instantiate(_prefabs[randomsayi], _humanSpawnPoint.transform.position, Quaternion.Euler(0, 0, 0));


        human.AddComponent<BoxCollider>();

        human.transform.localRotation = Quaternion.Euler(0, 0, 0);


        _humanList.Add(human);

    }

    public void DeleteHuman(GameObject deleteHuman)
    {


        for (int i = 0; i < _humanList.Count; i++)
        {
            if (deleteHuman == _humanList[i])
            {

                //_humanList[j].transform.parent = null;

                // _humanList.RemoveAt(j);

                Destroy(_humanList[i]);


            }

        }

    }


    public void BolHuman(int deleteHuman)
    {


        for (int i = 0; i < deleteHuman; i++)
        {


            //_humanList[j].transform.parent = null;

            // _humanList.RemoveAt(j);

            Destroy(_humanList[i]);




        }

    }

    public void ClearLists()
    {

        for (int i = 0; i < _humanList.Count; i++)
        {
            if (_humanList[i] == null)
            {
                _humanList.RemoveAt(i);
            }
        }

    }

    public void DestroyAllHuman()//Bunu Burhan Yazdı.
    {
        foreach (var human in _humanList)
        {
            Destroy(human);

        }
    }


    public void CikarmaIslemi(int cikarilcakSayi)
    {

        if (_humanList != null)
        {

            for (int i = _humanList.Count; 0 <= i; i--)
            {


                if (_humanList.Count >= cikarilcakSayi)
                {
                    for (int j = _humanList.Count; j > (_humanList.Count - cikarilcakSayi); j--)
                    {


                        Destroy(_humanList[j - 1]);
                    }
                }

                else if (_humanList.Count < cikarilcakSayi)
                {
                    for (int j = 0; j < _humanList.Count; j++)
                    {

                        Destroy(_humanList[j]);
                    }
                }


            }

        }

    }


    public void PlayerDeleteHuman()
    {
        if (_humanList.Count > 20)
        {
            int yuzdeyirmi = (int)(_humanList.Count * 0.3);
            CikarmaIslemi(yuzdeyirmi);


        }
        else if (_humanList.Count < 20)
        {
            int random = UnityEngine.Random.Range(5, 10);
            CikarmaIslemi(random);
        }
    }

}


