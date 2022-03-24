using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public static MenuButton instance;
    public Animator animator;

    private void Awake()
    {
        instance = this;
    }
    public void StartButt()
    {
        StartCoroutine(startBut());
    }

    public void Exitgame()
    {
        Application.Quit();
    }

    IEnumerator startBut()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Video");
    }
}
