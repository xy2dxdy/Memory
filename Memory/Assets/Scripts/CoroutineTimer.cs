using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CoroutineTimer : MonoBehaviour
{
    [SerializeField] public float time;
    [SerializeField] private Image timerImage;

    private float _timeLeft = 0f;

    private IEnumerator StartTimer()
    {
        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            var normalizedValue = Mathf.Clamp(_timeLeft / time, 0.0f, 1.0f);
            timerImage.fillAmount = normalizedValue;
            yield return null;
        }
        time = 0;
        Debug.Log("THE END");
    }

    private void Update()
    {
        if (_timeLeft == 0 && time != 0)
        {
            _timeLeft = time;
            StartCoroutine(StartTimer());
        }
    }
    public void IncreaseTime(int time)
    {
        this.time += time;
        _timeLeft += time;
    }
    public Image GetImage() { return timerImage; }
}