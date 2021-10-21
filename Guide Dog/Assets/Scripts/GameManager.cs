using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text scoreText;
    public Text levelText;
    public Text levelScoreText;

    public int score = 0;
    public int levelScore;


    public GameObject gameoverScreen;

    public GameObject gameStartScreen;

    public GameObject gameNextLevelScreen;
    public Button gameNextLevelButton;

    public LevelController levelController;

    public PlayerController playerController;

    public HumanController humanController;

    public GameObject player;

    public bool insanVarmi;

    private void Awake()
    {
        instance = this;
        Time.timeScale = 0.0f;
        gameoverScreen.SetActive(false);
        gameNextLevelScreen.SetActive(false);
    }

    void Start()
    {
        SaveGameGet();


    }


    void Update()
    {
        SaveGameSet();
        levelScoreText.text = levelScore.ToString();
        scoreText.text = score.ToString();
        

        if (humanController.countHuman > 0)
        {
            insanVarmi = true;
          
        }
        LoseGame();
    }

    public void AddPoint(int point)
    {
        score += point;
        levelScore += point;
    }

    public void StartGame()
    {
        Time.timeScale = 1.0f;
        gameStartScreen.SetActive(false);
    }

    public void LoseGame() 
    {
       if(insanVarmi && humanController.countHuman < 1)
        {

            gameoverScreen.SetActive(true);
            StopGame();
            insanVarmi = false;
        }



    }

    public void StopGame()
    {
        Time.timeScale = 0.0f;
    }

    public void RestartGame() 
    {

        gameoverScreen.SetActive(false);
        levelController.isCreated = false;
        levelController.RestartGame();
        playerController.PlayerStartPosition();
        StopGame();
        gameStartScreen.SetActive(true);


    }

    public void NextLevel() //GameNextLevel'deki nextLevel butonu bu methodu çalıştırır.
    {

        StartCoroutine(NextLevelMethod());

    }

    IEnumerator NextLevelMethod()
    {
        gameNextLevelButton.interactable = false;
        score = score + levelScore;
        yield return new WaitForSecondsRealtime(2);
        levelController.levelCount++;
        gameNextLevelScreen.SetActive(false);
        levelController.isCreated = false;
        playerController.PlayerStartPosition();
        gameStartScreen.SetActive(true);
        StopGame();
        RandomLevel();
        gameNextLevelButton.interactable = true;
    
    }

    public void FinishLevel() // FinisLevel bu methodu çağırır.
    {
        gameNextLevelScreen.SetActive(true);


    }
    private void SaveGameGet()
    {
        PlayerPrefs.DeleteAll();

        score = PlayerPrefs.GetInt("score");
        levelController.levelCount = PlayerPrefs.GetInt("level");
        levelController.randomLevel = PlayerPrefs.GetInt("randomlevel");
    }

    private void SaveGameSet()
    {
        PlayerPrefs.SetInt("randomlevel", levelController.randomLevel);



        PlayerPrefs.SetInt("level", levelController.levelCount);
        levelText.text = "Level " + (levelController.levelCount + 1).ToString(); //Level yazısı
   
        PlayerPrefs.SetInt("score", score);
        scoreText.text = "$ " + score.ToString();
    }

    private void RandomLevel()
    {
        levelController.randomLevel = UnityEngine.Random.Range(0, levelController.prefabLevels.Count);
    }

   
}
