using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Determines what the correct victory condition is depending on the level
/// </summary>
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

                if (collision.gameObject.tag == "Player")
                {
                    playerVictory.Raise();
                }

                break;
            case 2:               
            case 3:

                if (collision.gameObject.tag == "Player")
                {
                    if (playerColourLerp.Value == 0.5f && collision.gameObject.GetComponent<CurrentPlayerColour>().isColoured)
                    {
                        playerVictory.Raise();
                    }
                    else
                    {
                        wrongColour.Raise();
                        playerDeath.Raise();
                        gameObject.GetComponent<AudioSource>().Play();
                    }
                }
                

                break;
            default:
                break;
        }

        
    }
}
