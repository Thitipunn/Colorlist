using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogObject dialogObject;
    [SerializeField] private DialogObject dialogObject2;
    [SerializeField] private int dialogNum; //Change Dialog based on interger number +1

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && other.TryGetComponent(out PlayerMovement player))
        {
            player.Interactable = this;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out PlayerMovement player))
        {
            if (player.Interactable is DialogActivator dialogActivator && dialogActivator == this)
            {
                player.Interactable = null;
            }
        }
    }

    public void Interact(PlayerMovement player)
    {
        if (dialogNum == 1)
        {
            if (dialogNum == null) return;
            player.DialogUI.ShowDialog(dialogObject);
            dialogNum++; //plus to change context of dialog
        }
        else if (PlayerMovement.instace.Bluekey == 1 && dialogNum == 2)
        {
            if (dialogNum == null) return;
            player.DialogUI.ShowDialog(dialogObject2);
            dialogNum++;
        }

    }
}
