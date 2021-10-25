﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    [SerializeField] private List<GameObject> _leveller = new List<GameObject>();

    private int _levelNumarasi;

    private GameObject güncelLevel;

    private int _levelNumber;

    private int _toplamLevelSayisi;

    void Start()
    {
        if (güncelLevel)
        {
            Destroy(güncelLevel);
        }
        else
        {

        }
 
        _levelNumarasi = PlayerPrefs.GetInt("LevelNumarası", 0);
        _levelNumber = PlayerPrefs.GetInt("LevelNumber", 1);
        _toplamLevelSayisi = _leveller.Count - 1;

        if (_levelNumber < _toplamLevelSayisi)
        {
            _levelNumarasi = PlayerPrefs.GetInt("LevelNumarası");
            güncelLevel = Instantiate(_leveller[_levelNumarasi], new Vector3(0, 0, 0), Quaternion.identity);
        }
        else
        {
            _levelNumarasi = PlayerPrefs.GetInt("LevelNumarası");

            güncelLevel = Instantiate(_leveller[_levelNumarasi], new Vector3(0, 0, 0), Quaternion.identity);
        }



    }


    public void LevelDegistir()
    {
        Destroy(güncelLevel);
        _levelNumarasi = PlayerPrefs.GetInt("LevelNumarası");
        _levelNumber = PlayerPrefs.GetInt("LevelNumber");
        _toplamLevelSayisi = _leveller.Count - 1;

        if (_levelNumber < _toplamLevelSayisi)
        {
            _levelNumarasi = PlayerPrefs.GetInt("LevelNumarası");
            _levelNumarasi += 1;
            _levelNumber++;

            güncelLevel = Instantiate(_leveller[_levelNumarasi], new Vector3(0, 0, 0), Quaternion.identity);
            PlayerPrefs.SetInt("LevelNumarası", _levelNumarasi);
            PlayerPrefs.SetInt("LevelNumber", _levelNumber);
        }
        else
        {
            _levelNumarasi = PlayerPrefs.GetInt("LevelNumarası");
            int _geciciLevelNumarasi = _levelNumarasi;

            _levelNumarasi = Random.Range(0, _toplamLevelSayisi);

            if (_levelNumarasi == _geciciLevelNumarasi)
            {
                LevelDegistir();
            }
            else
            {
                _levelNumber++;
                güncelLevel = Instantiate(_leveller[_levelNumarasi], new Vector3(0, 0, 0), Quaternion.identity);
                PlayerPrefs.SetInt("LevelNumarası", _levelNumarasi);
                PlayerPrefs.SetInt("LevelNumber", _levelNumber);
            }
            //PlayerPrefs.SetInt("GüncelLevelNumarası", _güncelLevelNumarasi);



        }


    }

    public void LevelRestart()
    {
        Destroy(güncelLevel);
        _levelNumarasi = PlayerPrefs.GetInt("LevelNumarası");
        _toplamLevelSayisi = _leveller.Count - 1;

        if (_levelNumber < _toplamLevelSayisi)
        {
            _levelNumarasi = PlayerPrefs.GetInt("LevelNumarası");
            güncelLevel = Instantiate(_leveller[_levelNumarasi], new Vector3(0, 0, 0), Quaternion.identity);
        }
        else
        {
            _levelNumarasi = PlayerPrefs.GetInt("LevelNumarası");

            güncelLevel = Instantiate(_leveller[_levelNumarasi], new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
