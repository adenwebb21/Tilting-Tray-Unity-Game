using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ISS;

/// <summary>
/// Used for spawning the player in the correct place for each level
/// </summary>
public class PlayerSpawnManager : MonoBehaviour {

    [SerializeField]
    private Transform[] startingPos;

    [SerializeField]
    private FloatVariable playerColour;

    [SerializeField]
    private IntVariable level;

    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private GameEvent levelBoard;

    public void SpawnNewPlayer()
    {
        EraseAllCurrentPlayers();
        StartCoroutine(gameObject.CountDownFrom(1.4f, () => { ActuallySpawn(); }));
    }

    /// <summary>
    /// This is the function called from the coorroutine, this is because the level needs to have time to slide in
    /// </summary>
    private void ActuallySpawn()
    {
        Instantiate(playerPrefab, startingPos[level.Value].position, new Quaternion(0, 0, 0, 1));
    }

    /// <summary>
    /// Get rid of any players currently remaining in the scene as this causes issues for player locating later
    /// </summary>
    private void EraseAllCurrentPlayers()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject player in players)
        {
            Destroy(player);
        }
    }
}
