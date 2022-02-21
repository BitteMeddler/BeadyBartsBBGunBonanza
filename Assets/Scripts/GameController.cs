using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController SharedInstance;
    private int currentScore = 0;
    private float roundTime = 30;
    public bool isGameActive;

    public TextMeshProUGUI scoreNumberText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI timerNumberText;

    public Button startButton;
    public Button resetButton;
    public Button exitButton;

    private TargetController _targetController;
    public GameObject _countdownTimer;

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        _targetController = TargetController.SharedInstance;
        timerNumberText.text = "" + roundTime;
    }

    private void Update()
    {

    }

    public void ScoreTracker(int pointsFromTarget)
    {
        currentScore += pointsFromTarget;
        scoreNumberText.text = "" + currentScore;
    }

    public void GameEnd()
    {
        timerNumberText.text = "" + 0;
        isGameActive = false;
        _targetController.gameObject.SetActive(false);

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
        _targetController.gameObject.SetActive(true);
        _countdownTimer.gameObject.SetActive(true);
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
