using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetController : MonoBehaviour {

    [SerializeField]
    private FloatVariable traySpeed, initialAcceleration;

    [SerializeField]
    private IntVariable currentCheckpointTarget;

    private Vector3 startLocation;
    private Quaternion emptyRotation = Quaternion.identity;
    private Transform trayTransform;
    private TrayCheckpointMovement movementScript;


    private void Start()
    {
        trayTransform = GameObject.Find("Tray").transform;
        movementScript = gameObject.GetComponent<TrayCheckpointMovement>();
        startLocation = transform.position;
    }

    public void ResetPlayer()
    {
        transform.position = startLocation;
        transform.rotation = emptyRotation;
        trayTransform.rotation = emptyRotation;
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        traySpeed.Value = 0;
        initialAcceleration.Value = 0;      
        currentCheckpointTarget.Value = 0;

        movementScript.ResetTarget();

    }

}
