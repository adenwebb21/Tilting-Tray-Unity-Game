using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayCheckpointMovement : MonoBehaviour
{
    [SerializeField]
    private FloatVariable traySpeed, maxTraySpeed, initialAccelerationT;

    [SerializeField]
    private Transform[] checkpoints;

    [SerializeField]
    private float waypointThreshold, rotationSpeed;

    [SerializeField]
    private IntVariable currentCheckpointTarget;

    //private int currentCheckpointTarget;
    private Vector3 targetPosition;
    private Quaternion trayRotation;
    private Rigidbody trayBody;

    void Start()
    {
        trayBody = GetComponent<Rigidbody>();
        currentCheckpointTarget.Value = 0;
        traySpeed.Value = 0;
        initialAccelerationT.Value = 0;

        AquireTargetPosition();
    }

    void Update()
    {
        // When you reach a checpoint - select next one
        if (Vector3.Distance(transform.position, targetPosition) < waypointThreshold)
        {
            NextCheckpoint();
        }

        trayRotation = Quaternion.LookRotation(targetPosition - transform.position);
    }

    private void FixedUpdate()
    {
        // Slow at the start then slowly speed up
        traySpeed.Value = Mathf.Lerp(0, maxTraySpeed.Value, initialAccelerationT.Value);
        initialAccelerationT.Value += 0.1f * Time.deltaTime;

        trayBody.AddForce(transform.forward * traySpeed.Value);

        transform.rotation = Quaternion.Slerp(transform.rotation, trayRotation, Time.deltaTime * rotationSpeed);
    }

    private void NextCheckpoint()
    {
        if (currentCheckpointTarget.Value == checkpoints.Length - 1)
        {
            currentCheckpointTarget.Value = 0;
        }
        else
        {
            currentCheckpointTarget.Value++;
        }

        AquireTargetPosition();
    }

    public void ResetTarget()
    {
        currentCheckpointTarget.Value = 0;

        AquireTargetPosition();
    }

    private void AquireTargetPosition()
    {
        targetPosition = checkpoints[currentCheckpointTarget.Value].transform.position;
    }
}
