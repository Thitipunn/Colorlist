using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedForm : MonoBehaviour
{
    private void Update()
    {
        if(PlayerColor.color.RedForm == false)
        {
            Physics2D.IgnoreLayerCollision(6, 9, false);//6 = Blue
            Physics2D.IgnoreLayerCollision(7, 9, false);//7 = Red
            Physics2D.IgnoreLayerCollision(8, 9, false);//8 = Green
        }
        if (PlayerColor.color.RedForm == true)
        {
            Physics2D.IgnoreLayerCollision(6, 9,true);//6 = Blue
            Physics2D.IgnoreLayerCollision(7, 9,false);//7 = Red
            Physics2D.IgnoreLayerCollision(8, 9,true);//8 = Green
        }
        if (PlayerColor.color.BlueForm == true)
        {
            Physics2D.IgnoreLayerCollision(6, 9, false);//6 = Blue
            Physics2D.IgnoreLayerCollision(7, 9, true);//7 = Red
            Physics2D.IgnoreLayerCollision(8, 9, true);//8 = Green
        }
        if (PlayerColor.color.GreenForm == true)
        {
            Physics2D.IgnoreLayerCollision(6, 9, true);//6 = Blue
            Physics2D.IgnoreLayerCollision(7, 9, true);//7 = Red
            Physics2D.IgnoreLayerCollision(8, 9, false);//8 = Green
        }

    }
}
