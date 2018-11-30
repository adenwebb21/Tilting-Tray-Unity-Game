using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_Red : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<CurrentPlayerColour>().AddRed();
    }
}
