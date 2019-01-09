using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Adds red paint to the player
/// </summary>
public class TEST_Red : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<CurrentPlayerColour>().AddRed();
    }
}
