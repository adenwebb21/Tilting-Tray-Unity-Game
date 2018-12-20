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

    [SerializeField]
    private IntVariable currentLevel;

    private void OnTriggerEnter(Collider collision)
    {
        switch(currentLevel.Value)
        {
            case 0:
            case 1:

                if(collision.gameObject.tag == "Player")
                {
                    playerVictory.Raise();
                }

                break;
            case 2:

                if (collision.gameObject.tag == "Player" && playerColourLerp.Value == 0.5f && collision.gameObject.GetComponent<CurrentPlayerColour>().isColoured)
                {
                    playerVictory.Raise();
                    //uiScript.TriggerVictoryScreen();
                }
                else
                {
                    wrongColour.Raise();
                    playerDeath.Raise();
                    gameObject.GetComponent<AudioSource>().Play();
                }

                break;
            default:
                break;
        }

        
    }
}
