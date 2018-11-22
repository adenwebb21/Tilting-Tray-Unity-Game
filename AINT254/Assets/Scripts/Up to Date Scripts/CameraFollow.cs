using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float angleX, distance, height, rotationSmoothing;

    private Transform m_transform;

    private void Start()
    {
        m_transform = transform;
    }

    private void LateUpdate()
    {
        float angle = target.rotation.eulerAngles.y;

        //commented line is version without interpolation
        //m_transform.rotation = Quaternion.Euler(new Vector3(m_angleX, angle, 0.0f));
        m_transform.rotation = Quaternion.Slerp(m_transform.rotation, Quaternion.Euler(new Vector3(angleX, angle, 0.0f)), Time.deltaTime * rotationSmoothing);

        //cartesian using polar
        Vector3 offsetPosition = new Vector3(-distance * Mathf.Sin(angle * Mathf.Deg2Rad), height, -distance * Mathf.Cos(angle * Mathf.Deg2Rad));

        m_transform.position = target.position + offsetPosition;
    }
}
