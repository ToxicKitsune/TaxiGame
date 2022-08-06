using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UiManager : MonoBehaviour
{
    [SerializeField] TMP_Text timer;
    [SerializeField] float countDownTimerMax;
    [SerializeField] GameObject gameOver;

    [SerializeField] TMP_Text highScore;
    int highScoreStore = 0;

    [SerializeField] TMP_Text currentScore;
    int currentScoreStore=0;
    void Awake()
    {
        ScoreReset();
        SetHighScore();
    }
    public void ScoreReset()
    {
        currentScoreStore = 0;
        currentScore.text = currentScoreStore.ToString();
    }
    public void SetHighScore()
    {
        highScoreStore = currentScoreStore;
        highScore.text = highScoreStore.ToString();
    }
    public void InceaseScore()
    {
        currentScoreStore++;
        currentScore.text = currentScoreStore.ToString();
        if (highScoreStore < currentScoreStore)
        {
            SetHighScore();
        }
    }
    void FixedUpdate()
    {
        timer.text = countDownTimerMax.ToString();
        countDownTimerMax -= Time.deltaTime;

        if (countDownTimerMax<=0)
        {
            Debug.Log("GameOver");
            Time.timeScale = 0;
            gameOver.SetActive(true);
        }
        else
        {
            Debug.Log("GameInProgress");
        }
    }
}
