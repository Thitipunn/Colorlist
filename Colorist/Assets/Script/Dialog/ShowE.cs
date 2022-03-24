using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowE : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
        else
            gameObject.GetComponent<Renderer>().enabled = false;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }

}
