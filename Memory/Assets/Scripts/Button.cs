using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    //[SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color colorOnOver;
    [SerializeField] private Color colorOnExit;
    [SerializeField] private KeyCode keycode;

    private void OnMouseOver()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = colorOnOver;
        }
    }
    private void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = colorOnExit;
        }
    }
    private void OnMouseDown()
    {
        transform.localScale += new Vector3(.1f, .1f, .1f);
    }
    private void OnMouseUp()
    {
        transform.localScale -= new Vector3(.1f, .1f, .1f);
    }
}
