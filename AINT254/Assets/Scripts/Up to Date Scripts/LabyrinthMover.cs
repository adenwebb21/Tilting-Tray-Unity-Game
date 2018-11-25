using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthMover : MonoBehaviour
{

    [SerializeField]
    private float horizontalSpeed = 2.0F;
    [SerializeField]
    private float verticalSpeed = 2.0F;

    private float forwardRotation = 0;
    private float sidewaysRotation = 0;

    private float currentForwardRotation;
    private float currentSidewaysRotation;

    private Rigidbody trayRigidbody;
    private Quaternion trayRotation;
    private Transform labTransform;

    private bool reachedLimit = false;
    public float t;
    private Vector3 eulers;

    private Vector3 forwardRotationVector, sidewaysRotationVector;

    private void Start()
    {
        trayRigidbody = gameObject.GetComponent<Rigidbody>();
        labTransform = transform;
        reachedLimit = false;
    }

    void Update()
    {
        sidewaysRotation = horizontalSpeed * Input.GetAxis("Mouse X");
        forwardRotation = verticalSpeed * Input.GetAxis("Mouse Y");

        //forwardRotationVector = transform.right * forwardRotation;
        //sidewaysRotationVector = transform.forward * sidewaysRotation;

        forwardRotationVector = new Vector3(forwardRotation, 0, 0);
        sidewaysRotationVector = new Vector3(0, 0, sidewaysRotation);


        eulers = transform.rotation.eulerAngles;
        t = eulers.x;

        if ((eulers.x > 350 || eulers.x < 10) && (eulers.z > 355 || eulers.z < 5))
        {
            reachedLimit = false;
        }
        else
        {
            reachedLimit = true;
        }
    }

    private void FixedUpdate()
    {
        //if (reachedLimit)
        //{
        //    trayRigidbody.angularDrag = Mathf.Max(Mathf.Abs(eulers.x), Mathf.Abs(eulers.z)) * 0.5f;            
        //}

        transform.rotation = Quaternion.Euler(eulers.x, 0, eulers.z);
        trayRigidbody.angularVelocity = new Vector3(forwardRotation, 0, -sidewaysRotation);
    }
}
