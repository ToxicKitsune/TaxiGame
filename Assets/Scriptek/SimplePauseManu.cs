using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class SimplePauseManu : MonoBehaviour
{
    Taxi control;
    private void Awake()
    {
        control = new Taxi();
        control.TaxiIranyitas.Menu.started += _ => Menu();
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
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
