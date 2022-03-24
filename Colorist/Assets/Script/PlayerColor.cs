using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    public static PlayerColor color;

    public AnimatorOverrideController blueAnim;
    public AnimatorOverrideController redAnim;
    public AnimatorOverrideController greenAnim;

    public bool RedForm = false;
    public bool BlueForm = false;
    public bool GreenForm = false;

    private void Awake()
    {
        color = this;
    }

    public void BlueSkin()
    {
        GetComponent<Animator>().runtimeAnimatorController = blueAnim as RuntimeAnimatorController;
        BlueForm = true;
        RedForm = false;
        GreenForm = false;
    }
    public void RedSkin()
    {
        GetComponent<Animator>().runtimeAnimatorController = redAnim as RuntimeAnimatorController;
        BlueForm = false;
        RedForm = true;
        GreenForm = false;
    }
    public void GreenSkin()
    {
        GetComponent<Animator>().runtimeAnimatorController = greenAnim as RuntimeAnimatorController;
        BlueForm = false;
        RedForm = false;
        GreenForm = true;
    }
}
