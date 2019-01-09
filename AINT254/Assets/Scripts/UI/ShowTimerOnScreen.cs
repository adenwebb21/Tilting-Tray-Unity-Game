using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTimerOnScreen : MonoBehaviour {

    [SerializeField]
    private FloatVariable timer;

    private void Update()
    {
        // Rounding the timer value to 1 decimal place
        gameObject.GetComponent<Text>().text = timer.Value.ToString("f1");
    }
}
