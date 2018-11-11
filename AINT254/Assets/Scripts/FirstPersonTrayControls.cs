using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonTrayControls : MonoBehaviour
{
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;

    float forwardRotation = 0;
    float sidewaysRotation = 0;

    void Update()
    {
        forwardRotation = verticalSpeed * Input.GetAxis("Mouse X");
        sidewaysRotation = horizontalSpeed * Input.GetAxis("Mouse Y");


        transform.Rotate(sidewaysRotation, 0, (-1 * forwardRotation));       
    }

}
