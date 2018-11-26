using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactPit : MonoBehaviour {

    [SerializeField]
    private FloatVariable timer;

    private Material thisMaterial;

    private Color nearColour = Color.red;
    private Color farColour = Color.black;

    private float maxDistance = 0.5f;

    private GameObject player;
    private GameObject playerSpawner;

    private float timeToDeath = 0.3f;
    private float timestamp;

    private void Start()
    {
        playerSpawner = GameObject.FindGameObjectWithTag("PlayerSpawner");
        player = GameObject.FindGameObjectWithTag("Player");
        thisMaterial = GetComponent<Renderer>().material;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            timestamp = timeToDeath;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            timestamp -= Time.deltaTime;

            if (timestamp <= 0)
            {
                timer.Value += 10;
                playerSpawner.GetComponent<PlayerSpawnManager>().SpawnNewPlayer();

                other.gameObject.GetComponent<ResetPlayer>().DestroyThisPlayer();
            }
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
