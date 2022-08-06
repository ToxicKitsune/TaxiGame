using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celpont : MonoBehaviour
{
    [SerializeField] GameObject plusOneDisplay;
    void FixedUpdate()
    {
        
        if (plusOneDisplay.activeSelf)
        {
            plusOneDisplay.transform.position = new Vector3(
            plusOneDisplay.transform.position.x,
            plusOneDisplay.transform.position.y + 2f*Time.deltaTime
            );
            Debug.Log("Plus One Display Rised by " + plusOneDisplay.transform.position.y);
        }
        if (plusOneDisplay.transform.position.y >= -2f && plusOneDisplay.activeSelf)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Taxi")
        {
            if (collision.GetComponent<TaxiIranyitas>().insidePassenger)
            {
                collision.GetComponent<TaxiIranyitas>().insidePassenger = false;
                Debug.Log("Drop off");
                GameObject.FindGameObjectWithTag("Passanger").GetComponent<Felveheto>().RelocatePassenger();
                GameObject.FindGameObjectWithTag("UiManager").GetComponent<UiManager>().InceaseScore();
                plusOneDisplay.SetActive(true);
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                Debug.Log("Can't drop off");
            }
        }
    }
}
