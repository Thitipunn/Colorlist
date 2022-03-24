using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedHenshin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerColor.color.RedSkin();
            FindObjectOfType<SoundManager>().Play("ColorSwitch");
        }
    }
}
