using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusExtraTime : MemoryCard
{
    private int time = 0;
    [SerializeField] private CoroutineTimer coroutineTimer;
    private void Update()
    {
        if(time != 0)
            coroutineTimer.IncreaseTime(time);
    }


}
