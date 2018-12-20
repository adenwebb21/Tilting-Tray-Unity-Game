using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour {

    [SerializeField]
    private Transform startingPos;

    [SerializeField]
    private FloatVariable playerColour;

    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private GameEvent levelBoard;

    public void SpawnNewPlayer()
    {
        levelBoard.Raise();
        Instantiate(playerPrefab, startingPos.position, new Quaternion(0, 0, 0, 1));
    }
}
