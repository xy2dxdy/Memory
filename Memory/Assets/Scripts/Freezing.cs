using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Freezing : MonoBehaviour
{
    private MemoryCard[] _cards;
    private int _count = 0;
    private void Update()
    {
        if (_cards != null)
        {
            for (int i = 0; i < _cards.Length; i++)
            {
                if (_cards[i] == null)
                {
                    continue;
                }
                if (_cards[i].GetCardBack() == null)
                {
                    continue;
                }
                if (_cards[i].textF == null)
                    _cards[i].toFreeze(_count);
                else
                {
                    _cards[i].textF.GetComponent<TextMesh>().text = "" + _count;
                }
            }
        }
        if (_count == 0 && _cards != null)
        {
            foreach (MemoryCard card in _cards)
            {
                if (card == null)
                    continue;
                card.toUnfreeze();
            }
            _cards = null;
        }

    }
    public void toSetCard(MemoryCard[] cards)
    {
        _cards = cards;
        //Debug.Log(_cards[0].name);
    }
    public void toSetCount(int count)
    {
        _count = count;
    }
    public void toDecrease()
    {
        _count--;
    }
}
