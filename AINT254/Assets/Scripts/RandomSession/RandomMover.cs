using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMover : MonoBehaviour {

    private float xValue, zValue;
    private Transform m_transform;

    [SerializeField]
    private AnimationCurve curve;

    private void Start()
    {
        m_transform = transform;
    }

    private void Update()
    {
        //Step();
        //StepWithArray();
        //StepWithFloat();
        //StepWithCurve();
        StepWithVector();
    }

    private void Step()
    {
        int randomInt = Random.Range(0, 4);

        xValue = 0;
        zValue = 0;

        if(randomInt == 0)
        {
            xValue = 0.1f;
        }
        else if(randomInt == 1)
        {
            xValue = -0.1f;
        }
        else if(randomInt == 2)
        {
            zValue = 0.1f;
        }
        else
        {
            zValue = -0.1f;
        }

        m_transform.position += new Vector3(xValue, 0, zValue);

    }

    private void StepWithFloat()
    {
        float randomFloat = Random.Range(0, 1f);

        xValue = 0;
        zValue = 0;

        if (randomFloat <= 0.25f)
        {
            xValue = 0.1f;
        }
        else if (randomFloat <= 0.5f)
        {
            xValue = -0.1f;
        }
        else if (randomFloat <= 0.75f)
        {
            zValue = 0.1f;
        }
        else
        {
            zValue = -0.1f;
        }

        m_transform.position += new Vector3(xValue, 0, zValue);
    }

    private void StepWithVector()
    {
        xValue = Random.Range(-0.1f, 0.1f);
        zValue = Random.Range(-0.1f, 0.1f);

        m_transform.position += new Vector3(xValue, 0, zValue);
    }

    private void StepWithCurve()
    {
        float randomCurveValue = Random.Range(0, 1f);

        float randomFloat = curve.Evaluate(randomCurveValue);


        xValue = 0;
        zValue = 0;

        if (randomFloat <= 0.25f)
        {
            xValue = 0.1f;
        }
        else if (randomFloat <= 0.5f)
        {
            xValue = -0.1f;
        }
        else if (randomFloat <= 0.75f)
        {
            zValue = 0.1f;
        }
        else
        {
            zValue = -0.1f;
        }

        m_transform.position += new Vector3(xValue, 0, zValue);
    }

    private void StepWithArray()
    {
        int[] randomSelectorArray = { 0, 0, 1, 2, 3 };

        int randomIndex = Random.Range(0, 5);

        xValue = 0;
        zValue = 0;

        if (randomSelectorArray[randomIndex] == 0)
        {
            xValue = 0.1f;
        }
        else if (randomSelectorArray[randomIndex] == 1)
        {
            xValue = -0.1f;
        }
        else if (randomSelectorArray[randomIndex] == 2)
        {
            zValue = 0.1f;
        }
        else
        {
            zValue = -0.1f;
        }

        m_transform.position += new Vector3(xValue, 0, zValue);
    }

}
