using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ISS;

/// <summary>
/// Organises the levels and the transitions between them
/// </summary>
public class LevelManager : MonoBehaviour {

    private GameObject player;

    [SerializeField]
    private IntVariable startingLevel;

    [SerializeField]
    private GameEvent showInfo;

    [SerializeField]
    private Animator[] levelAnimators;

    [SerializeField]
    private IntVariable currentLevel;

    [SerializeField]
    private GameObject[] levels;

    private void Start()
    {      
        player = GameObject.FindGameObjectWithTag("Player");
        currentLevel.Value = startingLevel.Value;
        PositionLevels();
        player.transform.position = levels[currentLevel.Value].transform.Find("spawn").transform.position;
    }

    /// <summary>
    /// Puts all levels in their inactive positions and disables them - this is so the level selector doesn't confuse things by altering positions from a previous position
    /// </summary>
    private void PositionLevels()
    {
        foreach(GameObject level in levels)
        {
            level.transform.position = new Vector3(20, 0, 0);
            level.SetActive(false);
        }

        // Just activate correct one
        levels[currentLevel.Value].transform.position = new Vector3(0, 0, 0);
        levels[currentLevel.Value].SetActive(true);
    }

    /// <summary>
    /// Responds to the event of the same name
    /// </summary>
    public void OnNextLevel()
    {
        // Slides out current level
        levelAnimators[currentLevel.Value].Play("levelSlideLeft");
        StartCoroutine(gameObject.CountDownFrom(1.3f, () => { ResetLevelState(); }));

        // Selects next value, loops if final
        if (currentLevel.Value < levels.Length - 1)
        {
            currentLevel.Value++;
        }
        else
        {
            currentLevel.Value = 0;
        }

        // Slides in enxt level
        levels[currentLevel.Value].SetActive(true);
        levels[currentLevel.Value].transform.position = new Vector3(20, 0, 0);
        levelAnimators[currentLevel.Value].Play("levelSlideIn");
        gameObject.GetComponent<AudioSource>().Play();
    }

    /// <summary>
    /// Reverts previous level to the idle position
    /// </summary>
    private void ResetLevelState()
    {
        levels[currentLevel.Value - 1].SetActive(false);
        levels[currentLevel.Value - 1].transform.position = new Vector3(20, 0, 0);
    }
}
