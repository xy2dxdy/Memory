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
    [SerializeField] private Sprite imageFreeze;
    [SerializeField] private Sprite imageBack;
    [SerializeField] private GameObject text;
    
    private bool isFreeze = false;
    private Quaternion target;
    public GameObject textF;

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
        if (cardBack.activeSelf && controller.canReveal && !isFreeze)
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
    public void toFreeze(int score)
    {
        cardBack.GetComponent<SpriteRenderer>().sprite = imageFreeze;
        isFreeze = true;
        textF = Instantiate(text, transform.position + new Vector3(0, 0, -10), Quaternion.identity);
    }
    public void toUnfreeze()
    {
        isFreeze = false;
        cardBack.GetComponent<SpriteRenderer>().sprite = imageBack;
        Destroy(textF);
    }
    public void toSetText(string text)
    {
        textF.GetComponent<TextMesh>().text = text;
    }
    public void DestroyBack()
    {
        Destroy(cardBack);
    }
}
