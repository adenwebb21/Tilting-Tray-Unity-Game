using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousemovement : MonoBehaviour {

    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;

    float forwardRotation = 0;
    float sidewaysRotation = 0;

    void Update()
    {
        if(forwardRotation < -20 || forwardRotation > 20)
        {
            forwardRotation = 20;           
        }
        else
        {
            forwardRotation = horizontalSpeed * Input.GetAxis("Mouse Y");
        }

        if (sidewaysRotation < -20 || sidewaysRotation > 20)
        {
            sidewaysRotation = 20;
        }
        else
        {
            sidewaysRotation = verticalSpeed * Input.GetAxis("Mouse X");
        }

        transform.Rotate(forwardRotation, 0, (-1 * sidewaysRotation));
    }
}
