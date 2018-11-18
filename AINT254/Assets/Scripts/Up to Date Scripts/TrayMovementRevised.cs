using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayMovementRevised : MonoBehaviour
{

    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;

    float forwardRotation = 0;
    float sidewaysRotation = 0;

    private Rigidbody trayRigidbody;
    private Quaternion trayRotation;
    private Vector3 trayRotationVector;

    private void Start()
    {
        trayRigidbody = gameObject.GetComponent<Rigidbody>();
        trayRotationVector = new Vector3();
    }

    void Update()
    {
        sidewaysRotation = horizontalSpeed * Input.GetAxis("Mouse X");

        forwardRotation = verticalSpeed * Input.GetAxis("Mouse Y");

        trayRotationVector.x = forwardRotation;
        trayRotationVector.z = sidewaysRotation;
    }

    private void FixedUpdate()
    {
        Vector3 rotVec = new Vector3(trayRotationVector.x, 0, -trayRotationVector.z);
        Quaternion rot = Quaternion.Euler(rotVec);

        trayRigidbody.angularVelocity = rotVec;
    }
}
