using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonTrayControls : MonoBehaviour
{
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;

    float forwardRotation = 0;
    float sidewaysRotation = 0;

    private Rigidbody body;
    private Quaternion trayRotation;
    private Vector3 trayRotationVector;

    private void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
        trayRotationVector = new Vector3();
    }

    void Update()
    {
        forwardRotation = verticalSpeed * Input.GetAxis("Mouse X");
        sidewaysRotation = horizontalSpeed * Input.GetAxis("Mouse Y");

        trayRotationVector.x = forwardRotation;
        trayRotationVector.z = sidewaysRotation;

        //transform.Rotate(sidewaysRotation, 0, (-1 * forwardRotation));       
    }

    private void FixedUpdate()
    {
        Vector3 rotVec = new Vector3(trayRotationVector.x, 0, trayRotationVector.z);
        Quaternion rot = Quaternion.Euler(rotVec);

       // trayRotation = Quaternion.LookRotation(trayRotationVector, transform.up);

        //transform.Rotate(sidewaysRotation, 0, (-1 * forwardRotation));
        body.angularVelocity = rotVec * 1000;

        //if (trayRotationVector != Vector3.zero)
        //{
        //    trayRotation = Quaternion.LookRotation(trayRotationVector, transform.up);

        //    //transform.Rotate(sidewaysRotation, 0, (-1 * forwardRotation));
        //    body.MoveRotation(trayRotation);
        //}
        ////Debug.Log(trayRotationVector);
    }

}
