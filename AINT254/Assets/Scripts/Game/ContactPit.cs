using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is used for when the player comes into contact with a pit
/// </summary>
public class ContactPit : MonoBehaviour {

    [SerializeField]
    private GameEvent playerDeath;

    private Material thisMaterial;

    public Color nearColour = new Color();
    private Color farColour = Color.black;

    private float maxDistance = 0.5f;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        thisMaterial = GetComponent<Renderer>().material;
    }

    /// <summary>
    /// When the player collides with the collider at the bottom of the pit
    /// </summary>
    /// <param name="collision"> The collision between player and pit </param>
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerDeath.Raise();
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    // Colour changing script modified version of script by https://stackoverflow.com/users/3785314/programmer found here https://stackoverflow.com/questions/43419915/lerp-color-based-on-distance-between-2-objects
    private void Update()
    {
        if(player != null)
        {
            float distanceApart = getSqrDistance(player.transform.position, gameObject.transform.position);

            float lerp = mapValue(distanceApart, 0, maxDistance, 0f, 1f);

            Color lerpColor = Color.Lerp(nearColour, farColour, lerp);
            gameObject.GetComponent<Renderer>().material.color = lerpColor;
        }
        else
        {
            player = GameObject.FindGameObjectWithTag("Player");
            gameObject.GetComponent<Renderer>().material.color = farColour;
        }
    }

    public float getSqrDistance(Vector3 v1, Vector3 v2)
    {
        return (v1 - v2).sqrMagnitude;
    }

    float mapValue(float mainValue, float inValueMin, float inValueMax, float outValueMin, float outValueMax)
    {
        return (mainValue - inValueMin) * (outValueMax - outValueMin) / (inValueMax - inValueMin) + outValueMin;
    }
}
