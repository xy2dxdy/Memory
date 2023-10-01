using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private string targetMessage;
    public Color highlightColor = Color.cyan;

    private void OnMouseOver()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = highlightColor;
        }
    }
    private void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.color = Color.white;
        }
    }
    private void OnMouseDown()
    {
        transform.localScale += new Vector3(.1f, .1f, .1f);
    }
    private void OnMouseUp()
    {
        transform.localScale -= new Vector3(.1f, .1f, .1f);
        if (targetObject != null)
        {
            targetObject.SendMessage(targetMessage);
        }
    }
}
