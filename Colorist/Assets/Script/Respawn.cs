using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public static Respawn instance;

    [SerializeField]private Animator animator;
    public Vector2 respawnPoint;
    [SerializeField] private Transform StartPoint;
    public bool isFroze;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        respawnPoint = StartPoint.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ObjKiller"))
        {
            animator.SetBool("IsDied", true);
            FindObjectOfType<SoundManager>().Play("Damage");
            isFroze = true;
            StartCoroutine(respawn());   
        }
    }

    IEnumerator respawn()
    {
        yield return new WaitForSeconds(1);
        transform.position = respawnPoint;
        isFroze = false;
        animator.SetBool("IsDied", false);
    }
}
