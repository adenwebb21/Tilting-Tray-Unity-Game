using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPlayerColour : MonoBehaviour {

    [SerializeField]
    private FloatVariable currentColourLerp;

    private Renderer rend;
    private PlayerSoundManager playerSound;

    public bool isColoured;

    private void Start()
    {
        isColoured = false;
        rend = gameObject.GetComponent<Renderer>();
        playerSound = gameObject.GetComponent<PlayerSoundManager>();

        currentColourLerp.Value = 0.5f;
    }

    private void Update()
    {
        if(isColoured)
        {
            rend.material.color = Color.Lerp(Color.red, Color.blue, currentColourLerp.Value);
        }
    }

    public void AddBlue()
    {
        playerSound.AddPaint();
        isColoured = true;

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
        playerSound.AddPaint();
        isColoured = true;

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
