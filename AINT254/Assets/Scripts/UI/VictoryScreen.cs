using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour {

    [SerializeField]
    private UIController uiScript;

    [SerializeField]
    private GameEvent playerVictory, playerDeath, wrongColour;

    [SerializeField]
    private FloatVariable playerColourLerp;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && playerColourLerp.Value == 0.5f && collision.gameObject.GetComponent<CurrentPlayerColour>().isColoured)
        {
            playerVictory.Raise();
            //uiScript.TriggerVictoryScreen();
        }
        else
        {
            wrongColour.Raise();
            playerDeath.Raise();
        }
    }
}
