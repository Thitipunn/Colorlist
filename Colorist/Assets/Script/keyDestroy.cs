using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyDestroy : MonoBehaviour
{
    [SerializeField] private Collider2D stand;

    private void Update()
    {
        if (stand == null) return;
        Physics2D.IgnoreCollision(stand, gameObject.GetComponent<Collider2D>());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            FindObjectOfType<SoundManager>().Play("Key");
        }
    }
}
