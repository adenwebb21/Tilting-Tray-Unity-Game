using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ISS;

public class LevelManager : MonoBehaviour {

    private GameObject player;

    public int startingLevel;

    [SerializeField]
    private Animator[] levelAnimators;

    [SerializeField]
    private IntVariable currentLevel;

    [SerializeField]
    private GameObject[] levels;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentLevel.Value = startingLevel;
        player.transform.position = levels[currentLevel.Value].transform.Find("spawn").transform.position;
    }

    public void OnNextLevel()
    {
        levelAnimators[currentLevel.Value].Play("levelSlideLeft");
        StartCoroutine(gameObject.CountDownFrom(1.3f, () => { ResetLevelState(); }));

        if (currentLevel.Value < levels.Length - 1)
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

    private void ResetLevelState()
    {
        levels[currentLevel.Value - 1].SetActive(false);
        levels[currentLevel.Value - 1].transform.position = new Vector3(20, 0, 0);
    }
}
