using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    private float roundTime = 30;
    private int timer;

    private GameController gameController;

    private void Start()
    {
        gameController = GameController.SharedInstance;
    }

    private void Update()
    {
        CountDownTimer();
    }

    public void CountDownTimer()
    {
        timer = (int)(roundTime -= Time.deltaTime);
        if (timer > 0 && gameController.isGameActive == true)
        {
            gameController.timerNumberText.text = "" + timer;
        }
        else
        {
            gameController.GameEnd();
        }
    }
}
