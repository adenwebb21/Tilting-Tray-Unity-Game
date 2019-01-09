using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves the labyrinth with mouse movements
/// </summary>
public class LabyrinthMover : MonoBehaviour
{

    [SerializeField]
    private float horizontalSpeed = 2.0F;
    [SerializeField]
    private float verticalSpeed = 2.0F;

    private float forwardRotation = 0;
    private float sidewaysRotation = 0;

    private Rigidbody trayRigidbody;
    private Quaternion trayRotation;
    private Transform labTransform;

    [SerializeField]
    private BoolVariable isUnderPlayerControl;

    private Vector3 eulers;

    private Vector3 forwardRotationVector, sidewaysRotationVector;

    private void Start()
    {
        isUnderPlayerControl.Value = true;
        trayRigidbody = gameObject.GetComponent<Rigidbody>();
        labTransform = transform;
    }

    void Update()
    {
        if (isUnderPlayerControl.Value)
        {
            sidewaysRotation = horizontalSpeed * Input.GetAxis("Mouse X");
            forwardRotation = verticalSpeed * Input.GetAxis("Mouse Y");

            forwardRotationVector = new Vector3(forwardRotation, 0, 0);
            sidewaysRotationVector = new Vector3(0, 0, sidewaysRotation);

            eulers = transform.rotation.eulerAngles;
        }
        else if (Quaternion.Angle(labTransform.rotation, Quaternion.identity) <= 1f)
        {
            isUnderPlayerControl.Value = true;
        }
    }

    /// <summary>
    /// Moves the board based on the movements calculated previously
    /// </summary>
    private void FixedUpdate()
    {
        if(isUnderPlayerControl.Value)
        {
            transform.rotation = Quaternion.Euler(eulers.x, 0, eulers.z);
            trayRigidbody.angularVelocity = new Vector3(forwardRotation, 0, -sidewaysRotation);
        }
        
    }
}
