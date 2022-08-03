using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Felveheto : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        RelocatePassenger();
    }
    public void RelocatePassenger()
    {
        spriteRenderer.enabled = true;
        this.transform.position = new Vector3(Random.Range(-6.85f, 6.26f), this.transform.position.y);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Taxi")
        {
            if (collision.GetComponent<TaxiIranyitas>().insidePassenger)
            {
                Debug.Log("Taxi Is Full");
            }
            else
            {
                spriteRenderer.enabled = false;
                collision.GetComponent<TaxiIranyitas>().insidePassenger = true;
                collision.GetComponent<TaxiIranyitas>().MakeMarker();
            }
        }
    }
}
