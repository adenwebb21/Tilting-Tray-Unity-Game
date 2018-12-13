using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour {

    [SerializeField]
    private Transform startingPos;

    [SerializeField]
    private GameObject playerPrefab;

    public void SpawnNewPlayer()
    {
        Instantiate(playerPrefab, startingPos.position, new Quaternion(0, 0, 0, 1));
    }
}
