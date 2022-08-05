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
        this.transform.position = new Vector3(GetFelvehetoNewPosition(GameObject.FindGameObjectWithTag("Taxi").GetComponent<TaxiIranyitas>().lastMarkerPosition), this.transform.position.y);
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
    float GetFelvehetoNewPosition(float lastMarkerPos)
    {
        float newPosition;
        if (lastMarkerPos - 3 <= -6.85f)
        {
            newPosition = Random.Range(lastMarkerPos + 3, 6.25f);
        }
        else if (lastMarkerPos + 3 > 6.25f)
        {
            newPosition = Random.Range(-6.85f, lastMarkerPos - 3);
        }
        else if (Random.Range(1, 0) == 0)
        {
            newPosition = Random.Range(-6.85f, lastMarkerPos - 3);
        }
        else
        {
            newPosition = Random.Range(lastMarkerPos + 3, 6.25f);
        }
        return newPosition;
    }
}
