using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;


public class TaxiIranyitas : MonoBehaviour
{
    [SerializeField] GameObject self;
    Taxi control;
    Rigidbody2D rb2d;
    [SerializeField] float maxTaxiSpeed;
    [SerializeField] float taxiSpeed;
    [SerializeField] GameObject marker;
    float speed;
    public bool insidePassenger;
    public float lastMarkerPosition;

    private void Awake()
    {
        control = new Taxi();
        control.TaxiIranyitas.Iranyitas.started += _ => MoveTaxi(_.ReadValue<float>());
        control.TaxiIranyitas.Iranyitas.canceled += _ => SetSpeedToZero();
        control.TaxiIranyitas.Fek.performed+= _ => Break();
    }
    void Break()
    {
        rb2d.velocity = new Vector2(0f, 0f);
    }
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void SetSpeedToZero()
    {
        speed = 0;
    }
    void MoveTaxi(float i)
    {
        speed = i * taxiSpeed;
    }
    private void OnEnable()
    {
        control.Enable();    
    }
    private void OnDisable()
    {
        control.Disable();
    }
    private void Update()
    {
        if (this.transform.position.x < -8.95f)
        {
            self.transform.position = new Vector3(8.85f, self.transform.position.y, self.transform.position.z);
        }
        else if (this.transform.position.x > 8.95f)
        {

            self.transform.position = new Vector3(-8.85f, self.transform.position.y, self.transform.position.z);
        }
    }
    private void FixedUpdate()
    {
        if (rb2d.velocity.magnitude < maxTaxiSpeed)
        {
            rb2d.AddForce(new Vector2(speed * Time.deltaTime, 0));
        }
        if (rb2d.velocity.x != 0)
        {
            if (rb2d.velocity.x > 0.2)
            {
                self.GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (rb2d.velocity.x < -0.2)
            {
                self.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }
    public void MakeMarker()
    {
        if (insidePassenger)
        {
            //First we get the passenger's old X position +-3
            if (GameObject.FindGameObjectWithTag("Passanger").transform.position.x - 3f<=-6.85f)
            {

            }
            Instantiate(marker, new Vector3(GetMarkerNewPosition(GameObject.FindGameObjectWithTag("Passanger").transform.position.x), -3.0f, 0),
                Quaternion.identity);
        }
        else { Debug.Log("There are no passenger"); }
    }
    float GetMarkerNewPosition(float passangerPosition)
    {
        float newPosition;
        if (passangerPosition - 3 <= -6.85f)
        {
            newPosition = Random.Range(passangerPosition + 3, 6.25f);
        }
        else if (passangerPosition + 3 > 6.25f)
        {
            newPosition = Random.Range(-6.85f, passangerPosition - 3);
        }
        else if (Random.Range(1, 0) == 0)
        {
            newPosition = Random.Range(-6.85f, passangerPosition - 3);
        }
        else
        {
            newPosition = Random.Range(passangerPosition + 3, 6.25f);
        }
        lastMarkerPosition = newPosition;
        return newPosition;
    }
}
