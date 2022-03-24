using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class White_fade : MonoBehaviour
{
    public Animator animator;
    public GameObject whitefade;
    public static White_fade instance;

    private void Awake()
    {
        instance = this;
    }

    public void lastdoor()
    {
        StartCoroutine(endgame());
    }

    IEnumerator endgame()
    {
        whitefade.SetActive(true);
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Menu");
    }
}
