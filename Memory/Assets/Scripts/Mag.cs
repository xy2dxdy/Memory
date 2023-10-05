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

    public void CreateMag()
    {
        int number = Random.Range(0, 3);
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

}
