using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ImageLoop : MonoBehaviour
{
    //UI
    public float duration;
    [SerializeField] private Sprite[] sprites;
    private Image image;
    private int index = 0;
    private float timer = 0;
    //

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        if ((timer += Time.deltaTime) >= (duration / sprites.Length))
        {
            timer = 0;
            image.sprite = sprites[index];
            index = (index + 1) % sprites.Length;
        }
    }
}
