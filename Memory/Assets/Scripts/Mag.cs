using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Mag : MonoBehaviour
{
    [SerializeField] private BonusExtraTime extraTime;
    [SerializeField] private CardShuffler shuffler;
    [SerializeField] private SceneController sceneController;
    [SerializeField] private int amountTime = -20;
    [SerializeField] private AudioSource music;
    [SerializeField] private GameObject spawn;
    [SerializeField] private GameObject spawn1;
    [SerializeField] private SpriteRenderer lightningTime;
    [SerializeField] private SpriteRenderer lightningShuffle;
    [SerializeField] private SpriteRenderer lightningFreeze;
    [SerializeField] private AudioSource lightSound;
    [SerializeField] private ParticleSystem particle;

    private void Update()
    {
        if (GetComponent<SpriteRenderer>().enabled == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, spawn1.transform.position, Time.deltaTime * 10.0f);
        }
    }
    public void CreateMag()
    {
        int number = UnityEngine.Random.Range(0, 3);
        switch (number)
        {
            case 0:     
                StartCoroutine(CoroutineMag(lightningTime, extraTime.GetTimer().GetImage().transform.position));
                extraTime.SetTime(amountTime);
                break;
            case 1:
                Debug.Log("Freeze");
                StartCoroutine(CoroutineMag(lightningFreeze));
                sceneController.StartCoroutine(sceneController.Freeze());
                break;
            default:
                StartCoroutine(CoroutineMag(lightningShuffle, shuffler.GetSpawn().transform.position));
                StartCoroutine(CoroutineMagShuffle());
                break;
        }

    }
    private IEnumerator CoroutineMag(SpriteRenderer sprite, Vector3 pos)
    {
        GetComponent<SpriteRenderer>().enabled = true;
        music.volume /= 5;
        GetComponent<AudioSource>().enabled = true;
        yield return new WaitForSeconds(2f);
        GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(0.2f);
        lightSound.Play();
        sprite.enabled = true;

        Instantiate(particle, pos, Quaternion.identity);
        yield return new WaitForSeconds(0.8f);
        sprite.enabled = false;
        GameObject buf = spawn;
        spawn = spawn1;
        spawn1 = buf;
        GetComponent<Animator>().enabled = false;
        yield return new WaitForSeconds(2.5f);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<AudioSource>().enabled = false;
        music.volume *= 5;
    }
    private IEnumerator CoroutineMag(SpriteRenderer sprite)
    {
        GetComponent<SpriteRenderer>().enabled = true;
        music.volume /= 5;
        GetComponent<AudioSource>().enabled = true;
        yield return new WaitForSeconds(2f);
        GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(0.2f);
        lightSound.Play();
        sprite.enabled = true;
        yield return new WaitForSeconds(0.8f);
        sprite.enabled = false;
        GameObject buf = spawn;
        spawn = spawn1;
        spawn1 = buf;
        GetComponent<Animator>().enabled = false;
        yield return new WaitForSeconds(2.6f);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<AudioSource>().enabled = false;
        music.volume *= 5;
    }

    private IEnumerator CoroutineMagShuffle()
    {
        yield return new WaitForSeconds(2);
        shuffler.SetCards(sceneController.GetCards());
        shuffler.StartCoroutine(shuffler.toShuffle());
    }
    public AudioSource GetMusic() { return music; }

}
