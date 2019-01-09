using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages all the sounds associated with the player
/// </summary>
public class PlayerSoundManager : MonoBehaviour {

    private Rigidbody playerBody;

    private AudioSource ballRolling, ballHit, paintAdd, playerDeath;
    private AudioSource[] aSources;

    private float maxVelocity;

    private bool isSoundStopped;

    private void Start()
    {
        playerBody = gameObject.GetComponent<Rigidbody>();

        aSources = gameObject.GetComponents<AudioSource>();

        ballRolling = aSources[0];
        ballHit = aSources[1];
        paintAdd = aSources[3];
    }

    private void Update()
    {
        maxVelocity = GetHighestVelocity();

        if(playerBody.velocity != Vector3.zero && !ballRolling.isPlaying && !isSoundStopped)
        {           
            ballRolling.Play();
        }

        ballRolling.volume = Mathf.Clamp(GetHighestVelocity(), 0, 0.2f);
    }

    private void OnCollisionEnter(Collision collision)
    {    
        if(collision.collider.tag == "Wall")
        {
            Debug.Log(collision.collider.tag);

            // Ball hit volume is linked to the velocity of the ball and to a random pitch shift
            ballHit.volume = Mathf.Clamp(GetHighestVelocity(), 0, 0.6f);
            ballHit.pitch = 0 + Random.Range(0.4f, 2f);
            ballHit.Play();
        }
    }

    /// <summary>
    /// Gets the highest value comparing the x and z velocity of the ball
    /// </summary>
    /// <returns> the highest value </returns>
    private float GetHighestVelocity()
    {
        if(Mathf.Abs(playerBody.velocity.x) > Mathf.Abs(playerBody.velocity.z))
        {
            return Mathf.Abs(playerBody.velocity.x);
        }
        else
        {
            return Mathf.Abs(playerBody.velocity.z);
        }
    }

    /// <summary>
    /// Slightly random pitch o the paint splat as well
    /// </summary>
    public void AddPaint()
    {
        paintAdd.pitch = 0 + Random.Range(0.5f, 1.5f);
        paintAdd.Play();
    }

    public void StopAllSounds()
    {
        foreach(AudioSource sound in aSources)
        {
            sound.Stop();
            isSoundStopped = true;
        }
    }

    public void ResumeSounds()
    {
        isSoundStopped = false;
    }


}
