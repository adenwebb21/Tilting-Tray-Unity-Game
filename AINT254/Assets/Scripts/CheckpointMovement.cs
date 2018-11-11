﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointMovement : MonoBehaviour
{

    public float playerSpeed;
    public GameObject[] checkpoints;
    public float waypointThreshold;

    public int currentCheckpointTarget;
    private Vector3 targetPosition;
    private Quaternion playerRotation;
    private Vector3 m_EulerAngleVelocity;

    private Rigidbody playerBody;
    private Transform playerPos;
    private float rotationSpeed = 5f;

    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        playerPos = transform;

        playerBody.freezeRotation = true;

        currentCheckpointTarget = 0;
        targetPosition = checkpoints[currentCheckpointTarget].transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) < waypointThreshold)
        {
            NextCheckpoint();
        }

        playerRotation = Quaternion.LookRotation(targetPosition - transform.position);
    }

    private void FixedUpdate()
    {
        playerBody.AddForce(transform.forward * playerSpeed);

        transform.rotation = Quaternion.Lerp(transform.rotation, playerRotation, Time.deltaTime * rotationSpeed);
    }

    private void NextCheckpoint()
    {
        if(currentCheckpointTarget == checkpoints.Length - 1)
        {
            currentCheckpointTarget = 0;
        }
        else
        {
            currentCheckpointTarget++;
        }

        targetPosition = checkpoints[currentCheckpointTarget].transform.position;   
    }
}
