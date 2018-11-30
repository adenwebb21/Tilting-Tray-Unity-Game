using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPlayerColour : MonoBehaviour {

    [SerializeField]
    private FloatVariable currentColourLerp;

    private Renderer rend;

    private bool isUncoloured;

    private void Start()
    {
        isUncoloured = true;
        rend = gameObject.GetComponent<Renderer>();
    }

    private void Update()
    {
        if(!isUncoloured)
        {
            rend.material.color = Color.Lerp(Color.red, Color.blue, currentColourLerp.Value);
        }
    }

    public void AddBlue()
    {
        isUncoloured = false;

        if(currentColourLerp.Value != 0f)
        {
            currentColourLerp.Value = 1f;
        }
        else
        {
            currentColourLerp.Value = 0.5f;
        }
    }

    public void AddRed()
    {
        isUncoloured = false;

        if (currentColourLerp.Value != 1f)
        {
            currentColourLerp.Value = 0f;
        }
        else
        {
            currentColourLerp.Value = 0.5f;
        }
    }
}
