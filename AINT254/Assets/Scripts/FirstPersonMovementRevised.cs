using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovementRevised : MonoBehaviour {

    public float forwardSpeed, strafeSpeed;

    private Rigidbody playerBody;
    public Vector3 inputs;
    private Transform playerPos;

    public float t = 0;

    private void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        playerPos = transform;
        playerBody.freezeRotation = true;
    }

    private void Update()
    {
        inputs = new Vector3(Input.GetAxis("Horizontal"), 0, 1);

        inputs.z = Mathf.Lerp(0, 1, t);
        t += 0.1f * Time.deltaTime;

        
        //playerPos.position += new Vector3(inputs.x * strafeSpeed, 0, inputs.z * forwardSpeed);
        //playerBody.velocity = new Vector3(inputs.x * strafeSpeed, 0, inputs.z * forwardSpeed);
    }

    private void FixedUpdate()
    {
        playerBody.AddForce(new Vector3(inputs.x * strafeSpeed, 0, inputs.z * forwardSpeed));
    }
}
