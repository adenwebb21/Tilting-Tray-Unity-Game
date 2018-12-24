using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    private GameObject player;

    [SerializeField]
    private Animator[] levelAnimators;

    [SerializeField]
    private IntVariable currentLevel;

    [SerializeField]
    private GameObject[] levels;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentLevel.Value = 2;
        player.transform.position = levels[currentLevel.Value].transform.Find("spawn").transform.position;
    }

    public void OnNextLevel()
    {
        levelAnimators[currentLevel.Value].Play("levelSlideLeft");

        if(currentLevel.Value < levels.Length - 1)
        {
            currentLevel.Value++;
        }
        else
        {
            currentLevel.Value = 0;
        }

        levels[currentLevel.Value].SetActive(true);
        levels[currentLevel.Value].transform.position = new Vector3(20, 0, 0);
        levelAnimators[currentLevel.Value].Play("levelSlideIn");
    }
}
