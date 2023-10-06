using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Mag : MonoBehaviour
{
    [SerializeField] private BonusExtraTime extraTime;
    [SerializeField] private CardShuffler shuffler;
    [SerializeField] private SceneController sceneController;
    [SerializeField] private int amountTime = -20;
    [SerializeField] private GameObject mag;
    [SerializeField] private AudioSource music;
    public void CreateMag()
    {
        int number = Random.Range(0, 3);
        StartCoroutine(CoroutineMag());
            switch (number)
        {
            case 0:
                Debug.Log("Time");
                extraTime.SetTime(amountTime);
                break;
            case 1:
                Debug.Log("Freeze");
                sceneController.StartCoroutine(sceneController.Freeze());
                break;
            default:
                Debug.Log("Shuffle");
                shuffler.SetCards(sceneController.GetCards());
                shuffler.StartCoroutine(shuffler.toShuffle());
                break;
        }

    }
    private IEnumerator CoroutineMag()
    {
        mag.GetComponent<SpriteRenderer>().enabled = true;
        mag.GetComponent<Animator>().enabled = true;
        music.volume /= 10;
        mag.GetComponent<AudioSource>().enabled = true;
        yield return new WaitForSeconds(2);
        mag.GetComponent<SpriteRenderer>().enabled = false;
        mag.GetComponent<Animator>().enabled = false;
        yield return new WaitForSeconds(5);
        mag.GetComponent<AudioSource>().enabled = false;
        music.volume *= 10;
    }
}
