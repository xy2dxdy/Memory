using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CoroutineTimer : MonoBehaviour
{
    [SerializeField] public float time;
    [SerializeField] private Image timerImage;
    [SerializeField] private SpriteRenderer spriteDefeat;
    [SerializeField] private GameObject menuEnd;
    [SerializeField] private Pause pause;
    [SerializeField] private AudioSource end;
    [SerializeField] private AudioSource music;

    private float _timeLeft = 0f;

    private IEnumerator StartTimer()
    {
        while (_timeLeft > 0)
        {
            if (pause.GetPause() == true || menuEnd.activeSelf == true)
            {
                yield return null;
            }
            else
            {
                _timeLeft -= Time.deltaTime;
                var normalizedValue = Mathf.Clamp(_timeLeft / time, 0.0f, 1.0f);
                timerImage.fillAmount = normalizedValue;
                yield return null;
            }
        }
        time = 0;
        Time.timeScale = 0;
        music.enabled = false;
        end.Play();
        spriteDefeat.enabled = true;
        menuEnd.SetActive(true);
        Debug.Log("THE END");
    }
    private void Start()
    {
        _timeLeft = time;
        StartCoroutine(StartTimer());
    }
    //private void Update()
    //{
    //    if (_timeLeft == 0 && time != 0)
    //    {
    //        _timeLeft = time;
    //        StartCoroutine(StartTimer());
    //    }
    //}
    public void IncreaseTime(int time)
    {
        this.time += time;
        _timeLeft += time;
    }
    public Image GetImage() { return timerImage; }

}