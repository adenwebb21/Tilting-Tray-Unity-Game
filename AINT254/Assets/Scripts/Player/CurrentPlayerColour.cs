using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the current colour of the player based on paint
/// </summary>
public class CurrentPlayerColour : MonoBehaviour {

    [SerializeField]
    private FloatVariable currentColourLerp;

    private Renderer rend;
    private PlayerSoundManager playerSound;

    // Adjustable from the editor
    public Color red = new Color();
    public Color blue = new Color();

    public bool isColoured;

    private void Start()
    {
        isColoured = false;
        rend = gameObject.GetComponent<Renderer>();
        playerSound = gameObject.GetComponent<PlayerSoundManager>();

        // Starts neutral so that any colour addition takes it to that colour
        currentColourLerp.Value = 0.5f;
    }

    private void Update()
    {
        if (isColoured)
        {
            rend.material.color = Color.Lerp(red, blue, currentColourLerp.Value);
        }
    }

    public bool GetIsColoured
    {
        get
        {
            return isColoured;
        }
    }

    // Used for adding colours correctly
    #region Add Colours
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
    #endregion
}
