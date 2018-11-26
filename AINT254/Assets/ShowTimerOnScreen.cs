using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTimerOnScreen : MonoBehaviour {

    [SerializeField]
    private FloatVariable timer;

    private void Update()
    {
        gameObject.GetComponent<Text>().text = "Timer: " + timer.Value.ToString("f1");
    }
}
