using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawn : MonoBehaviour
{
    public static KeySpawn instance;

    [SerializeField] private GameObject RedKey;
    [SerializeField] private GameObject BlueKey;
    [SerializeField] private GameObject Candy;

    private void Start()
    {
        RedKey.SetActive(false);
        BlueKey.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(SpawnKey());
        }
    }

    IEnumerator SpawnKey()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(Candy);
        RedKey.SetActive(true);
        BlueKey.SetActive(true);
    }
}
