using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private MemoryCard originalCard;
    [SerializeField] private Sprite[] images;
    [SerializeField] private TextMesh scoreLabel;

    public const int gridRows = 2;
    public const int gridCols = 7;
    public const float offsetX = 2.5f;
    public const float offsetY = 3f;

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
        Vector3 startPos = originalCard.transform.position;
        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6};
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
            }
        }

        
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
    private IEnumerator CheckMatch()
    {
        if (_firstRevealed.id == _secondRevealed.id)
        {
            _score++;
            scoreLabel.text = "Score: " + _score;
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

    //[System.Obsolete]
    public void Restart()
    {
        Application.LoadLevel("SampleScene");
    }
}
