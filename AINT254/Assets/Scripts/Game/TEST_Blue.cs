using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Adds blue paint to the player
/// </summary>
public class TEST_Blue : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<CurrentPlayerColour>().AddBlue();
    }
}
