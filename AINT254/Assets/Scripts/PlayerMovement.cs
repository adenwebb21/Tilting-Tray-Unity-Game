using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Transform playerTransform;
    public float speed = 1;
    public float rotationSpeed = 0.5f;

    // Use this for initialization
    void Start()
    {
        playerTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            playerTransform.position += transform.forward * speed;
        }
        if(Input.GetKey(KeyCode.S))
        {
            playerTransform.position -= transform.forward * speed;
        }
        if(Input.GetKey(KeyCode.A))
        {
            playerTransform.Rotate(Vector3.down * rotationSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerTransform.Rotate(Vector3.up * rotationSpeed);
        }

    }
}
