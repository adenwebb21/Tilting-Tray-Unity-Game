using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayMovementRevised : MonoBehaviour
{
    [SerializeField]
    private float horizontalSpeed = 2.0F;
    [SerializeField]
    private float verticalSpeed = 2.0F;

    private float forwardRotation = 0;
    private float sidewaysRotation = 0;

    private Rigidbody trayRigidbody;
    private Quaternion trayRotation;

    private Vector3 forwardRotationVector, sidewaysRotationVector;

    private void Start()
    {
        trayRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        sidewaysRotation = horizontalSpeed * Input.GetAxis("Mouse X");
        forwardRotation = verticalSpeed * Input.GetAxis("Mouse Y");

        forwardRotationVector = transform.right * forwardRotation;
        sidewaysRotationVector = transform.forward * sidewaysRotation;      
    }

    private void FixedUpdate()
    {
        trayRigidbody.angularVelocity = forwardRotationVector - sidewaysRotationVector;
    }
}
