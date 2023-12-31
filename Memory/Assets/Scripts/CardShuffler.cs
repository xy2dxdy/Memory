using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
public class CardShuffler : MonoBehaviour
{
    [SerializeField] private GameObject spawn;
    [SerializeField] private int steps = 5;
    private MemoryCard[] cards = null;
    private MemoryCard[] newCards = null;
    private int kol = 0;
    private MemoryCard card = null;
    public bool start = false;

    private void Update()
    {
        if (cards != null && card != null)
        {
            Vector3 delta = spawn.transform.position - card.transform.position;
            float distance = delta.magnitude;
            card.transform.position = Vector3.MoveTowards(card.transform.position, spawn.transform.position, Time.deltaTime * steps * distance);
        }
    }
    public void SetCards(MemoryCard[] cards)
    {
        this.cards = cards;
    }
    public IEnumerator toShuffle()
    {
        yield return new WaitForSeconds(0.5f);
        MemoryCard[] new1Cards = new MemoryCard[cards.Length];
        cards.CopyTo(new1Cards, 0);
        
        
        newCards = new MemoryCard[cards.Length];
        for(int i = 0; i < cards.Length; i++)
        {
            if (cards[i] == null)
            {
                continue;
            }
            if (cards[i].transform.rotation == Quaternion.Euler(0.0f, 0.0f, 0.0f))
            {
                newCards[kol++] = cards[i];
            }
        }
        Vector3[] positions = new Vector3[newCards.Length];
        for (int i = 0; i < kol; i++)
        {
            positions[i] = newCards[i].transform.position;
        }
        StartCoroutine(toTransform(newCards, positions));
    }
    private MemoryCard[] ShuffleArray(MemoryCard[] cards)
    {
        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i].transform.rotation == Quaternion.Euler(0.0f, 0.0f, 0.0f))
            {
                MemoryCard buf = cards[i];
                int r = Random.Range(i, cards.Length);
                while (cards[r].transform.rotation != Quaternion.Euler(0.0f, 0.0f, 0.0f))
                    r = Random.Range(i, cards.Length);
                cards[i] = cards[r];
                cards[r] = buf;
            }

        }
        return cards;
    }
    private Vector3[] ShuffleArray(Vector3[] positions)
    {
        for (int i = 0; i < kol; i++)
        {
            Vector3 pos = positions[i];
            int r = Random.Range(i, kol);
            positions[i] = positions[r];
            positions[r] = pos;
        }
        return positions;
    }

    private IEnumerator toTransform(MemoryCard[] cards, Vector3[] positions)
    {
        yield return new WaitForSeconds(0.2f);
        start = true;
        for (int i = 0; i < kol; i++)
        {
            card = cards[i];
            yield return new WaitForSeconds(0.1f);
        }
        positions = ShuffleArray(positions);
        Vector3 spawn1 = spawn.transform.position;
        int p = 0;
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < kol && p < kol; i++)
        {
            spawn.transform.position = positions[i];
            card = cards[p++];
            yield return new WaitForSeconds(0.1f);
        }
        spawn.transform.position = spawn1;
        card = null;
        this.cards = null;
    }
    public GameObject GetSpawn() { return spawn; }
}
