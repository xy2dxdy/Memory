using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPair : MonoBehaviour
{
    [SerializeField] private SceneController controller;
    private MemoryCard[] cards;
    private MemoryCard card;
    public void SetCards(MemoryCard[] cards)
    {
        this.cards = cards;
    }
    public void SetCard(MemoryCard card)
    {
        this.card = card;
    }

    public void Find()
    {
        Debug.Log(card);
        foreach (MemoryCard card in cards) 
        {
            if (card.Equals(this.card))
            { 
                card.Turn();
                controller.CardRevealed(card);
                break;
            }
        }
    }
}
