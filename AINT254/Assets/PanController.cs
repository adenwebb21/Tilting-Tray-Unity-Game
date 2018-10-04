using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanController : MonoBehaviour
{
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;

    float forwardRotation = 0;
    float sidewaysRotation = 0;

    // For lerp
    public Transform startMarker;
    public Transform endMarker;

    public float speed = 10F;

    private float startTime;

    private float journeyLength;

    void Update()
    {
        forwardRotation = verticalSpeed * Input.GetAxis("Mouse Y");
        //sidewaysRotation = horizontalSpeed * Input.GetAxis("Mouse X");


        transform.Rotate(sidewaysRotation, 0, (-1 * forwardRotation));

        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);

        if(Input.GetKey(KeyCode.W))
        {
            LerpPan();
        }
    }

    void LerpPan()
    {
        

        // Distance moved = time * speed.
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed = current distance divided by total distance.
        float fracJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
    }

}

