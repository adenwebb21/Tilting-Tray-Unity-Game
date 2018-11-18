using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayCheckpointMovement : MonoBehaviour
{

    public float traySpeed;
    public float maxTraySpeed;
    public GameObject[] checkpoints;
    public float waypointThreshold;

    public int currentCheckpointTarget;
    private Vector3 targetPosition;
    private Quaternion trayRotation;

    private Rigidbody trayBody;
    private Transform trayPos;
    private float rotationSpeed = 2f;
    public float t = 0;

    void Start()
    {
        trayBody = GetComponent<Rigidbody>();
        trayPos = transform;

        currentCheckpointTarget = 0;
        targetPosition = checkpoints[currentCheckpointTarget].transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) < waypointThreshold)
        {
            NextCheckpoint();
        }

        traySpeed = Mathf.Lerp(0, maxTraySpeed, t);
        t += 0.1f * Time.deltaTime;

        trayRotation = Quaternion.LookRotation(targetPosition - transform.position);
    }

    private void FixedUpdate()
    {
        trayBody.AddForce(transform.forward * traySpeed);

        transform.rotation = Quaternion.Slerp(transform.rotation, trayRotation, Time.deltaTime * rotationSpeed);
    }

    private void NextCheckpoint()
    {
        if (currentCheckpointTarget == checkpoints.Length - 1)
        {
            currentCheckpointTarget = 0;
        }
        else
        {
            currentCheckpointTarget++;
        }

        targetPosition = checkpoints[currentCheckpointTarget].transform.position;
    }

    public void ResetTarget()
    {
        currentCheckpointTarget = 0;
        targetPosition = checkpoints[currentCheckpointTarget].transform.position;
    }
}
