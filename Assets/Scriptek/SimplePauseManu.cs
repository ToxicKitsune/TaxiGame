using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
public class SimplePauseManu : MonoBehaviour
{
    [SerializeField] GameObject Pause;
    Taxi control;
    private void Awake()
    {
        control = new Taxi();
        control.Manu.Menu.started += _ => Menu();
    }
    private void OnEnable()
    {
        control.Enable();
    }
    private void OnDisable()
    {
        control.Disable();
    }
    void Menu()
    {
        Debug.Log("Menu Open/Close");
        Pause.SetActive(!Pause.activeSelf);
        if (Pause.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
            Time.timeScale = 1;

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
