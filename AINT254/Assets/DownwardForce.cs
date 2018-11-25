using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownwardForce : MonoBehaviour {

	void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(0, -100, 0);
    }
}
