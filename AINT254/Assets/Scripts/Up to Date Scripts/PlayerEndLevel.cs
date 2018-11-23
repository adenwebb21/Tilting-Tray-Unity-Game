using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEndLevel : MonoBehaviour {

    public pauseManager winScreen;

    private void OnTriggerEnter(Collider other)
    {
        winScreen.ShowWinScreen();
    }
}
