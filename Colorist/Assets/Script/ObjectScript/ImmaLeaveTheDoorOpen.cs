using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmaLeaveTheDoorOpen : MonoBehaviour
{
    public bool IsOpen;
    public Animator animator;

    public void lastdoor()
    {
        if (!IsOpen && PlayerMovement.instace.Redkey == 1 && PlayerMovement.instace.Bluekey == 1 && PlayerMovement.instace.Greenkey == 1)
        {
            animator.SetBool("IsOpen", IsOpen);
            FindObjectOfType<SoundManager>().Play("OpenDoor");
            White_fade.instance.lastdoor();
        }
            
    }

    public void DoorOpen()
    {
        if (!IsOpen && PlayerMovement.instace.Redkey == 1 && PlayerMovement.instace.Bluekey == 1)
        {
            IsOpen = true;
            Debug.Log("Door open");
            animator.SetBool("IsOpen", IsOpen);
            FindObjectOfType<SoundManager>().Play("OpenDoor");
            StartCoroutine(NextScene());
        }
    }

    public void DoorOpenSesami()
    {
        if (!IsOpen && PlayerMovement.instace.Redkey == 1 && PlayerMovement.instace.Bluekey == 1 && PlayerMovement.instace.Greenkey == 1)
        {
            IsOpen = true;
            Debug.Log("Door open");
            animator.SetBool("IsOpen", IsOpen);
            FindObjectOfType<SoundManager>().Play("OpenDoor");
            StartCoroutine(NextScene());
        }
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(0.5f);
        LevelLoader.instance.LoadNextLevel();
    }
}
