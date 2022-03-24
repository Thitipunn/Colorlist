using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private TMP_Text textlabel;

    public bool IsOpen { get; private set; }

    private TypeWriter typeWriter;

    private void Start()
    {
        typeWriter = GetComponent<TypeWriter>();
        CloseDialogBox();
    }

    public void ShowDialog(DialogObject dialogObject)
    {
        IsOpen = true;
        dialogBox.SetActive(true);
        StartCoroutine(StepThroughDialog(dialogObject));
    }

    private IEnumerator StepThroughDialog(DialogObject dialogObject)
    {
        foreach(string dialog in dialogObject.Dialog)
        {
            yield return typeWriter.Run(dialog,textlabel);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
            FindObjectOfType<SoundManager>().Play("Button");
        }

        CloseDialogBox();
    }

    private void CloseDialogBox()
    {
        IsOpen = false;
        dialogBox.SetActive(false);
        textlabel.text = string.Empty;
    }
}
