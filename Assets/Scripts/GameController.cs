using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int currentScore = 0;
    private float roundTime = 30;
    public bool isGameActive;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI timerText;

    public Button startButton;
    public Button resetButton;
    public Button exitButton;

    private SpawnManager spawnController;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        spawnController = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        timerText.text = "Time: " + roundTime;
    }

    private void Update()
    {

        if (isGameActive)
        {
            CountDownTimer();
        }

    }

    public void ScoreTracker(int pointsFromTarget)
    {
        currentScore += pointsFromTarget;
        scoreText.text = "Score: " + currentScore;
    }

    public int CountDownTimer()
    {
        int timer = (int)(roundTime -= Time.deltaTime);
        if (timer > 0 && isGameActive == true)
        { 
            timerText.text = "Time: " + timer;
        }
        else
        {
            GameEnd();   
        }
        return timer;
        
    }

    public void GameEnd()
    {
        timerText.text = "Time: " + 0;

        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        resetButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartGame()
    {
        startButton.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        isGameActive = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
