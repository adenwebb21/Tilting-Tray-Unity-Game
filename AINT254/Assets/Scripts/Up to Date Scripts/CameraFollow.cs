using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private Transform target;
    [SerializeField]
    private float smoothSpeed = 1f;
    [SerializeField]
    private Vector3 offset;

    [SerializeField]
    private float distance = 10.0f;
    // the height we want the camera to be above the target
    [SerializeField]
    private float height = 5.0f;

    private void LateUpdate()
    {
        //float desiredRotation = target.eulerAngles.y;
        //float desiredHeight = target.position.y + height;

        //float currentRotation = transform.eulerAngles.y;
        //float currentHeight = transform.position.y;

        //currentRotation = Mathf.LerpAngle(currentRotation, desiredRotation, smoothSpeed * Time.deltaTime);
        //currentHeight = Mathf.Lerp(currentHeight, desiredHeight, smoothSpeed * Time.deltaTime);

        //Quaternion currentRotationQuat = Quaternion.Euler(0, currentRotation, 0);

        //transform.position = target.position;
        //transform.position -= currentRotation * Vector3.forward * distance;

        //transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        //transform.LookAt(target);

        transform.position = new Vector3(target.position.x, 2, target.position.z + (target.forward.z * -2));
        transform.LookAt(target);
    }
}
