using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    private Transform cubeTransform;
    public float speed = 1;

    // Use this for initialization
    void Start()
    {
        cubeTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        cubeTransform.position += transform.forward * speed;
    }
}
