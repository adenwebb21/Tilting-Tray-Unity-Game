using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEndLevel : MonoBehaviour {

    public pauseManager pause;

    private void OnTriggerEnter(Collider other)
    {        
        pause.Pause();
    }
}
