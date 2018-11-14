using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetController : MonoBehaviour {

    private Vector3 startLocation;

    private Transform trayTransform;

    private void Start()
    {
        trayTransform = GameObject.Find("Tray").transform;
        startLocation = transform.position;
    }

    public void ResetPlayer()
    {
        transform.position = startLocation;
        GetComponent<CheckpointMovement>().playerSpeed = 0;
        GetComponent<CheckpointMovement>().t = 0;

        trayTransform.rotation = new Quaternion(0f, 0f, 0f, 0f);
    }

}
