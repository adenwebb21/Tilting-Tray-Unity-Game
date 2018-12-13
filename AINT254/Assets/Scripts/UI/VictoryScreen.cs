using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour {

    [SerializeField]
    private UIController uiScript;

    [SerializeField]
    private FloatVariable playerColourLerp;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && playerColourLerp.Value == 0.5f && collision.gameObject.GetComponent<CurrentPlayerColour>().isColoured)
        {
            uiScript.TriggerVictoryScreen();
        }
    }
}
