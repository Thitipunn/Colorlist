using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCredit : MonoBehaviour
{
    public GameObject credit;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            credit.SetActive(false);
        }
    }

    public void showCredit()
    {
        credit.SetActive(true);
    }
}
