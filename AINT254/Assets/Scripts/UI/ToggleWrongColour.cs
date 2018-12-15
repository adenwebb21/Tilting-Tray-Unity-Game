using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleWrongColour : MonoBehaviour {

    [SerializeField]
    private Text wrongcolourText;

    private Color normalColour;

    public float alpha;

    private void Update()
    {
        alpha = wrongcolourText.color.a;
    }

    private void Start()
    {
        normalColour = wrongcolourText.color;
        wrongcolourText.CrossFadeAlpha(0.0f, 0.01f, false);
    }

    public void OnWrongColour()
    {
        if(wrongcolourText.color.a > 0f)
        {
            wrongcolourText.CrossFadeAlpha(0.0f, 2f, false);
        }
        else
        {
            wrongcolourText.color = normalColour;           
        }   
    }
}
