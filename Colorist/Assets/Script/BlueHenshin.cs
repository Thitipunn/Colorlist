using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueHenshin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerColor.color.BlueSkin();
            FindObjectOfType<SoundManager>().Play("ColorSwitch");
        }
    }
}

