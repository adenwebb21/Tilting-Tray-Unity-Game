using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthMover : MonoBehaviour
{

    [SerializeField]
    private float horizontalSpeed = 2.0F;
    [SerializeField]
    private float verticalSpeed = 2.0F;

    private float forwardRotation = 0;
    private float sidewaysRotation = 0;

    //private float currentForwardRotation;
    //private float currentSidewaysRotation;

    private Rigidbody trayRigidbody;
    private Quaternion trayRotation;
    private Transform labTransform;

    [SerializeField]
    private BoolVariable isUnderPlayerControl;

    //private bool reachedLimit = false;
    //public float t;
    private Vector3 eulers;

    private Vector3 forwardRotationVector, sidewaysRotationVector;

    private void Start()
    {
        isUnderPlayerControl.Value = true;
        trayRigidbody = gameObject.GetComponent<Rigidbody>();
        labTransform = transform;
        //reachedLimit = false;
    }

    void Update()
    {
        if (isUnderPlayerControl.Value)
        {
            sidewaysRotation = horizontalSpeed * Input.GetAxis("Mouse X");
            forwardRotation = verticalSpeed * Input.GetAxis("Mouse Y");

            //forwardRotationVector = transform.right * forwardRotation;
            //sidewaysRotationVector = transform.forward * sidewaysRotation;

            forwardRotationVector = new Vector3(forwardRotation, 0, 0);
            sidewaysRotationVector = new Vector3(0, 0, sidewaysRotation);

            eulers = transform.rotation.eulerAngles;
            //t = eulers.x;

            //if ((eulers.x > 350 || eulers.x < 10) && (eulers.z > 355 || eulers.z < 5))
            //{
            //    reachedLimit = false;
            //}
            //else
            //{
            //    reachedLimit = true;
            //}
        }
        else if (Quaternion.Angle(labTransform.rotation, Quaternion.identity) <= 1f)
        {
            isUnderPlayerControl.Value = true;
        }
    }

    //IEnumerator ReturnBoardRotationToZero()
    //{
    //    while (labTransform.rotation != Quaternion.identity)
    //    {
    //        labTransform.rotation = Quaternion.Slerp(labTransform.rotation, Quaternion.identity, Time.deltaTime * 3);
    //        yield return null;
    //    }       
    //}

    public void OnLevelBoard()
    {
        isUnderPlayerControl.Value = false;
        //StartCoroutine("ReturnBoardRotationToZero");
    }

    private void FixedUpdate()
    {
        //if (reachedLimit)
        //{
        //    trayRigidbody.angularDrag = Mathf.Max(Mathf.Abs(eulers.x), Mathf.Abs(eulers.z)) * 0.5f;            
        //}

        if(isUnderPlayerControl.Value)
        {
            transform.rotation = Quaternion.Euler(eulers.x, 0, eulers.z);
            trayRigidbody.angularVelocity = new Vector3(forwardRotation, 0, -sidewaysRotation);
        }
        
    }
}
