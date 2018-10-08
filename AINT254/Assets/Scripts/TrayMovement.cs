using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayMovement : MonoBehaviour
{
    private Transform rightHand, leftHand;
    private HingeJoint rightArmHinge, leftArmHinge;
    private JointSpring defaultRight, defaultLeft, extendedRight, extendedLeft;

    public float tiltSpeed = 1;

    public float sidewaysRotation;

    // Use this for initialization
    void Start()
    {
        leftHand = transform.GetChild(0);
        leftArmHinge = leftHand.GetComponent<HingeJoint>();
        defaultLeft = leftArmHinge.spring;

        rightHand = transform.GetChild(1);
        rightArmHinge = rightHand.GetComponent<HingeJoint>();
        defaultRight = rightArmHinge.spring;
    }

    // Update is called once per frame
    void Update()
    {
        // want a target position between -10 and 50 degrees

        //sidewaysRotation = Input.GetAxis("Mouse X");
        //right.targetPosition -= sidewaysRotation * tiltSpeed;
        //left.targetPosition -= sidewaysRotation * tiltSpeed;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            extendedRight.targetPosition = 50;
            extendedLeft.targetPosition = 0;

            extendedLeft.spring = 50;
            extendedRight.spring = 50;

            rightArmHinge.spring = extendedRight;
            leftArmHinge.spring = extendedLeft;
        }

        if (Input.GetKey(KeyCode.E))
        {
            extendedRight.targetPosition = 0;
            extendedLeft.targetPosition = -50;

            extendedLeft.spring = 50;
            extendedRight.spring = 50;

            rightArmHinge.spring = extendedRight;
            leftArmHinge.spring = extendedLeft;
        }
    }
}
