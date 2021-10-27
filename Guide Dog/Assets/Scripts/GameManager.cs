using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject _tapToStartScreen;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _loseScreen;

    [SerializeField] private Text _tapToStartScreenElmasText;
    [SerializeField] private Text _gameScreenElmasText;
    [SerializeField] private Text _gameScreenLevelText;
    [SerializeField] private Text _winScreenElmasText;
    [SerializeField] private Text _loseScreenElmasText;


    private int _levelElmasSayisi;
    private int _toplamElmasSayisi;

    

    public LevelController levelController;

    public PlayerController playerController;

    public HumanController humanController;

    public GameObject player;

    private int _levelNumber;

    //public bool insanVarmi;


    public static bool _gameActive;

    public static bool _oyunSonu;

    public static bool _oyunSonuSevinme;

    private void Awake()
    {
        instance = this;
       // Time.timeScale = 0.0f;
       
    }

    void Start()
    {
        _toplamElmasSayisi = PlayerPrefs.GetInt("ToplamElmasSayisi");
        _levelElmasSayisi = 0;
        _gameActive = false;
        _oyunSonu = false;
        _oyunSonuSevinme = false;
        _loseScreen.SetActive(false);
        _winScreen.SetActive(false);
        _tapToStartScreen.SetActive(true);
        PuanObjesiScript._oyunSonuXDegeri = 0;

    }


    void Update()
    {
        _levelNumber = PlayerPrefs.GetInt("LevelNumber");
        _gameScreenElmasText.text = _toplamElmasSayisi.ToString();
        _tapToStartScreenElmasText.text = _toplamElmasSayisi.ToString();
        _gameScreenLevelText.text = "LEVEL " + _levelNumber;


    }

    public void AddPoint(int point)
    {
        _toplamElmasSayisi = PlayerPrefs.GetInt("ToplamElmasSayisi");
        _levelElmasSayisi += point;
        _toplamElmasSayisi += point;
        PlayerPrefs.SetInt("ToplamElmasSayisi", _toplamElmasSayisi);
    }

    

    public void StartGame()
    {

        _toplamElmasSayisi = PlayerPrefs.GetInt("ToplamElmasSayisi");
        _levelElmasSayisi = 0;
        _gameActive = true;
        _oyunSonu = false;
        _oyunSonuSevinme = false;
        _tapToStartScreen.SetActive(false);
        _gameScreen.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().DogWalk();
        PuanObjesiScript._oyunSonuXDegeri = 0;
    }

    public void LoseGame() 
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().DogIdle();
        _gameScreen.SetActive(false);
        _loseScreen.SetActive(true);
        _gameActive = false;
        _loseScreenElmasText.text = _levelElmasSayisi.ToString();

    }

   

    public void RestartGame() 
    {
        _oyunSonu = false;
        _oyunSonuSevinme = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>().CameraReset();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().DogIdle();
        OyunSonuElmasHesapalama();
        levelController.LevelRestart();
        _loseScreen.SetActive(false);
        playerController.PlayerStartPosition();
        _gameActive = false;
        _gameScreen.SetActive(true);


    }

    public void NextLevel() //GameNextLevel'deki nextLevel butonu bu methodu çalıştırır.
    {
        _oyunSonu = false;
        _oyunSonuSevinme = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>().CameraReset();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().DogIdle();
        OyunSonuElmasHesapalama();
        playerController.PlayerStartPosition();
        _winScreen.SetActive(false);
        levelController.LevelDegistir();
        _gameActive = false;
        _tapToStartScreen.SetActive(true);
        

    }

    public void FinishLevel() // FinisLevel bu methodu çağırır.
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().DogIdle();
        _gameScreen.SetActive(false);
        _gameActive = false;
        _winScreen.SetActive(true);
        _levelElmasSayisi = _levelElmasSayisi * PuanObjesiScript._oyunSonuXDegeri;
        _winScreenElmasText.text = _levelElmasSayisi.ToString();


    }

    private void OyunSonuElmasHesapalama()
    {
        _toplamElmasSayisi = PlayerPrefs.GetInt("ToplamElmasSayisi");
        _toplamElmasSayisi += _levelElmasSayisi;
        PlayerPrefs.SetInt("ToplamElmasSayisi", _toplamElmasSayisi);
    }

  
   
}
