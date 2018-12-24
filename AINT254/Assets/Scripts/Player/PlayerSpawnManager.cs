using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ISS;

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
        levelBoard.Raise();
        StartCoroutine(gameObject.CountDownFrom(1.4f, () => { ActuallySpawn(); }));
    }

    private void ActuallySpawn()
    {
        Instantiate(playerPrefab, startingPos[level.Value].position, new Quaternion(0, 0, 0, 1));
    }
}
