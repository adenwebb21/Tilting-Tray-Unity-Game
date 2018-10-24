using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisionsWithEverythingExceptTray : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "TrayItems")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }
}

