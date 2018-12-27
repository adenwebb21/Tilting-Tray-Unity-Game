using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ISS;

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

    public void StartTimer(float delay)
    {
        StopTimer();
        timer.Value = 0f;
        StartCoroutine(gameObject.CountDownFrom(delay, () => { StartDelayed(); }));        
    }

    private void StartDelayed()
    {
        isTimerStopped = false;
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

    public void AddPenalty(float seconds)
    {
        timer.Value += seconds;
    }
}
