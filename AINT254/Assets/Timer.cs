using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    [SerializeField]
    private FloatVariable timer;

    private bool isTimerStopped = false;

    private void Start()
    {
        StartTimer();
    }

    public void StartTimer()
    {
        timer.Value = 0;
    }

    public void StopTimer()
    {
        isTimerStopped = true;
    }

    private void Update()
    {
        if(!isTimerStopped)
        {
            timer.Value += Time.deltaTime;
        }       
    }
}
