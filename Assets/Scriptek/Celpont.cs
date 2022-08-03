using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celpont : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Taxi")
        {
            if (collision.GetComponent<TaxiIranyitas>().insidePassenger)
            {
                collision.GetComponent<TaxiIranyitas>().insidePassenger = false;
                Debug.Log("Drop off");
                GameObject.FindGameObjectWithTag("Passanger").GetComponent<Felveheto>().RelocatePassenger();
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Can't drop off");
            }
        }
    }
}
