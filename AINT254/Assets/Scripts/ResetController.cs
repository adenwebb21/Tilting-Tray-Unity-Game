using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetController : MonoBehaviour {

    private Vector3 startLocation;
    private Quaternion startRotation;

    private Transform trayTransform;
    private CheckpointMovement movementScript;

    private void Start()
    {
        trayTransform = GameObject.Find("Tray").transform;
        movementScript = gameObject.GetComponent<CheckpointMovement>();
        startLocation = transform.position;
        startRotation = transform.rotation;
    }

    public void ResetPlayer()
    {
        transform.position = startLocation;
        transform.rotation = startRotation;
        movementScript.playerSpeed = 0;
        movementScript.t = 0;
        

        trayTransform.rotation = new Quaternion(0f, 0f, 0f, 0f);

        movementScript.ResetTarget();
    }

}
