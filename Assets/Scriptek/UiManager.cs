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

    [SerializeField] GameObject countDown;

    float countDownFromFive = 6;
    
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
        countDownTimerMax++;
        currentScore.text = currentScoreStore.ToString();
        if (highScoreStore < currentScoreStore)
        {
            SetHighScore();
        }
    }
    void FixedUpdate()
    {
        
        if (countDownFromFive <= 0)
        {
            timer.text = "Time: " + Mathf.Floor(countDownTimerMax).ToString();
            countDownTimerMax -= Time.deltaTime;
        }
        else
        {
            countDownFromFive -= Time.deltaTime;
            if (countDownFromFive<=0)
            {
                countDown.SetActive(false);
                GameObject.FindGameObjectWithTag("Taxi").GetComponent<TaxiIranyitas>().enabled = true;
            }else countDown.GetComponent<TMP_Text>().text = Mathf.Floor(countDownFromFive).ToString();
        }
        if (countDownTimerMax<=0)
        {
            Debug.Log("GameOver");
            Time.timeScale = 0;
            gameOver.SetActive(true);
            GameObject.FindGameObjectWithTag("EndGameScore").GetComponent<TMP_Text>().text = "Score:" + highScoreStore;
        }
        else
        {
            Debug.Log("GameInProgress");
        }
    }
}
