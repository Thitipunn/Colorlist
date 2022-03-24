using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;
    public Animator transition;

    void Awake()
    {
        instance = this;
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        Respawn.instance.isFroze = true;
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(2);
        //Respawn.instance.isFroze = false;
        SceneManager.LoadScene(levelIndex);
    }
}
