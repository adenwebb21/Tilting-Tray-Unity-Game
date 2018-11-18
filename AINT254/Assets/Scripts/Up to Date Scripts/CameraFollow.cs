using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    public float smoothSpeed = 1f;

    public Vector3 offset;

    private Vector3 velocity = Vector3.zero;
    private Vector3 targetRotation = new Vector3();

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        transform.position = smoothedPosition;

        targetRotation.y = target.rotation.y;

        transform.rotation = Quaternion.Euler(targetRotation);
    }
}
