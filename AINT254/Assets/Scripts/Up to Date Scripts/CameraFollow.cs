using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float m_angleX;
    [SerializeField]
    private float m_distance;
    [SerializeField]
    private float height;

    private Transform m_transform;

    private void Start()
    {
        m_transform = transform;
    }

    private void LateUpdate()
    {
        //we get the rotation angle of the player
        float angle = target.rotation.eulerAngles.y;

        //we rotate the camera with the same angle
        //m_transform.rotation = Quaternion.Euler(new Vector3(m_angleX, angle, 0.0f));
        m_transform.rotation = Quaternion.Slerp(m_transform.rotation, Quaternion.Euler(new Vector3(m_angleX, angle, 0.0f)), Time.deltaTime * 7);

        //we calculate the cartesian coordinates using the polar coordinates
        Vector3 offsetPosition = new Vector3(-m_distance * Mathf.Sin(angle * Mathf.Deg2Rad), height, -m_distance * Mathf.Cos(angle * Mathf.Deg2Rad));

        //we use the player position plus the offset calculated above
        m_transform.position = target.position + offsetPosition;
    }
}
