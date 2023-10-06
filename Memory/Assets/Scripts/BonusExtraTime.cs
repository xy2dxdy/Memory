using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class BonusExtraTime : MonoBehaviour
{
    private int time = 0;
    [SerializeField] private CoroutineTimer coroutineTimer;
    private void Update()
    {
    }
    public void SetTime(int time)
    {
        this.time = time;
        coroutineTimer.IncreaseTime(time);
    }
    public CoroutineTimer GetTimer() { return coroutineTimer; }

}
