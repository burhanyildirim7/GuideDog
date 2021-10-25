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


    public int score = 0;
    public int levelScore;

    public LevelController levelController;

    public PlayerController playerController;

    public HumanController humanController;

    public GameObject player;

    //public bool insanVarmi;


    public static bool _gameActive;

    private void Awake()
    {
        instance = this;
       // Time.timeScale = 0.0f;
       
    }

    void Start()
    {

        _gameActive = false;
        _loseScreen.SetActive(false);
        _winScreen.SetActive(false);
        _tapToStartScreen.SetActive(true);

    }


    void Update()
    {
       
        _gameScreenElmasText.text = levelScore.ToString();
        _tapToStartScreenElmasText.text = score.ToString();

        
       
    }

    public void AddPoint(int point)
    {
        score += point;
        levelScore += point;
    }

    public void StartGame()
    {
        _gameActive = true;
        _tapToStartScreen.SetActive(false);
        _gameScreen.SetActive(true);
    }

    public void LoseGame() 
    {
        _gameScreen.SetActive(false);
        _loseScreen.SetActive(true);
        _gameActive = false;

    }

   

    public void RestartGame() 
    {
        levelController.LevelRestart();
        _loseScreen.SetActive(false);
        playerController.PlayerStartPosition();
        _gameActive = false;
        _gameScreen.SetActive(true);


    }

    public void NextLevel() //GameNextLevel'deki nextLevel butonu bu methodu çalıştırır.
    {

        levelController.LevelDegistir();
        _winScreen.SetActive(false);
        playerController.PlayerStartPosition();
        _gameActive = false;
        _tapToStartScreen.SetActive(true);

    }

    public void FinishLevel() // FinisLevel bu methodu çağırır.
    {
        _gameScreen.SetActive(false);
        _gameActive = false;
        _winScreen.SetActive(true);


    }

  
   
}
