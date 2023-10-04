using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class OpeningRandomCards : MonoBehaviour
{
    [SerializeField] private int amountOfRandomCards = 4;
    public void Open(MemoryCard[] cards)
    {
        int p = 1;
        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i] != null && cards[i].transform.rotation == Quaternion.Euler(0.0f, 0.0f, 0.0f))
            {
                StartCoroutine(OpenCard(cards[i]));
                if(p++ == amountOfRandomCards)
                    break;
            }

        }
    }

    private IEnumerator OpenCard(MemoryCard card)
    {
        card.Turn();
        yield return new WaitForSeconds(2);
        card.Turn();
    }
}
