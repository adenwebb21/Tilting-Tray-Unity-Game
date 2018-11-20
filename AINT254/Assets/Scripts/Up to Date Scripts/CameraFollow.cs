using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offset;

    public float targetQuat;

    private void LateUpdate()
    {
        transform.rotation = new Quaternion(0, target.rotation.y, 0, 1);
        targetQuat = target.rotation.y;
        transform.position = target.position;
        transform.position -= transform.rotation * Vector3.forward * offset.z;

        transform.position = new Vector3(transform.position.x, offset.y, transform.position.z);

        transform.LookAt(target);
    }
}
