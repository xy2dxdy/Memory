using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private MemoryCard originalCard;
    [SerializeField] private Sprite[] images;
    [SerializeField] private TextMesh scoreLabel;
    [SerializeField] private int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 12, 13, 13, 14, 14, 15, 15}; //26
    [SerializeField] private MemoryCard[] cards;
    [SerializeField] private Freezing freezing;
    [SerializeField] private GameObject spawn1;
    [SerializeField] private GameObject spawn2;
    [SerializeField] private GameObject spawn3;
    private int numberOfCards = 0;
    public const int gridRows = 4;
    public const int gridCols = 8;
    public const float offsetX = 3f;
    public const float offsetY = 3.5f;

    private MemoryCard _firstRevealed;
    private MemoryCard _secondRevealed;
    private int _score = 0;
    public bool canReveal { get { return _secondRevealed == null; } }

    public void CardRevealed(MemoryCard card)
    {
        if (_firstRevealed == null)
        {
            _firstRevealed = card;
        }
        else
        {
            _secondRevealed = card;
            StartCoroutine(CheckMatch());
        }
    }
    void Start()
    {
        cards = new MemoryCard[numbers.Length];
        Vector3 startPos = originalCard.transform.position;
        
        numbers = ShuffleArray(numbers);
        for (int i = 0; i < gridCols; i++)
        {
            for (int j = 0; j < gridRows; j++)
            {
                MemoryCard card;
                if (i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as MemoryCard;
                }
                int index = j * gridCols + i;
                int id = numbers[index];
                card.SetCard(id, images[id]);
                float posX = offsetX * i + startPos.x;
                float posY = -offsetY * j + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
                cards[numberOfCards++] = card;
            }
        }
        StartCoroutine(Mixed(0));
        StartCoroutine(Mixed(30));
        StartCoroutine(Freeze());



    }
    private int[] ShuffleArray(int[] numbers)
    { 
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }
    private MemoryCard[] ShuffleArray(MemoryCard[] cards)
    {
        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i].transform.rotation == Quaternion.Euler(0.0f, 0.0f, 0.0f))
            {
                Vector3 pos = cards[i].transform.position;
                int r = Random.Range(i, cards.Length);
                while(cards[r].transform.rotation != Quaternion.Euler(0.0f, 0.0f, 0.0f))
                    r = Random.Range(i, cards.Length);
                cards[i].transform.position = cards[r].transform.position;
                cards[r].transform.position = pos;
            }
            
        }
        return cards;
    }
    private IEnumerator CheckMatch()
    {
        if (_firstRevealed.id == _secondRevealed.id)
        {
            if (_firstRevealed.id == 13)
            {
                _firstRevealed.transform.position = spawn1.transform.position;
                _firstRevealed.DestroyBack();

                Destroy(_secondRevealed.gameObject);
            }
            if (_firstRevealed.id == 14)
            {
                _firstRevealed.transform.position = spawn2.transform.position;
                _firstRevealed.DestroyBack();
                Destroy(_secondRevealed.gameObject);
            }
            if (_firstRevealed.id == 15)
            {
                _firstRevealed.transform.position = spawn3.transform.position;
                _firstRevealed.DestroyBack();
                Destroy(_secondRevealed.gameObject);
            }
            _score++;
            scoreLabel.text = "Score: " + _score;
            freezing.toDecrease();
        }
        else
        {
            yield return new WaitForSeconds(.5f);
            _firstRevealed.Unrevel();
            _secondRevealed.Unrevel();
        }
        _firstRevealed = null;
        _secondRevealed = null;
    }

    [System.Obsolete]
    public void Restart()
    {
        Application.LoadLevel("SampleScene");
    }
    private IEnumerator Mixed(int time)
    {
        yield return new WaitForSeconds(time);
        cards = ShuffleArray(cards);
    }
    private IEnumerator Freeze()
    {
        cards = ShuffleArray(cards);
        MemoryCard[] mass = new MemoryCard[3];
        for (int i = 0; i < 3; i++)
        {
            mass[i] = cards[i];
        }
        yield return new WaitForSeconds(5);
        freezing.toSetCard(mass);
        freezing.toSetCount(3);
    }
    public MemoryCard[] GetCards()
    {
        return cards;
    }
    public MemoryCard GetFirstRevealed()
    {
        return _firstRevealed;
    }
}
