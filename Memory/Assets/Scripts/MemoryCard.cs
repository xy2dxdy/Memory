using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MemoryCard : MonoBehaviour
{
    [SerializeField] private GameObject cardBack;
    [SerializeField] private Sprite image;
    [SerializeField] private SceneController controller;
    private Quaternion target;

    private int _id;
    public int id
    {
        get { return _id; }
    }
    public void SetCard(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;

    }
    private void Start()
    {
        target = transform.rotation;
    }
    private void OnMouseDown()
    {
        if (cardBack.activeSelf && controller.canReveal)
        {
            Turn();
            controller.CardRevealed(this);
        }
    }
    public void Unrevel()
    {
        Turn();
    }
    private void Update()
    {
        if (transform.rotation != target)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * 5f);
        }
    }
    public void Turn()
    {
        target *= Quaternion.Euler(0.0f, 180.0f, 0.0f);
    }
}
