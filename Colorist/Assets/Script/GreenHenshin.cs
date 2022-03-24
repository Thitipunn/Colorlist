using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenHenshin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerColor.color.GreenSkin();
            FindObjectOfType<SoundManager>().Play("ColorSwitch");
        }
    }
}
