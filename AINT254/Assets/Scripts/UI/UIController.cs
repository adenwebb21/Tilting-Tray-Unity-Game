using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ISS;
using UnityEngine.UI;

/// <summary>
/// Manages all of the UI in the game
/// </summary>
public class UIController : MonoBehaviour {

    [SerializeField]
    private LockCursor cursorScript;

    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private IntVariable currentLevel;

    [SerializeField]
    private GameObject victoryScreen, levelInfo;

    [SerializeField]
    private Animator wrongColourAnimator, plusTenAnimator;

    [SerializeField]
    private GameEvent nextLevel, restartLevel;

    [SerializeField]
    private PlayerSoundManager playerSound;

    private bool isVictoryActive = false;

    [SerializeField]
    private string[] levelInfos;

    private void Start()
    {       
        Resume();
    }

    private void Update()
    {
        // Gets player sound manager if the original player is dead
        if(playerSound == null && GameObject.FindGameObjectWithTag("Player"))
        {
            playerSound = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSoundManager>();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !isVictoryActive)
        {
            if (pauseMenu.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void ReturnToTitleScreen()
    {
        SceneManager.LoadScene("LabyrinthTitle");
    }

    public void Pause()
    {
        cursorScript.Unlock();
        playerSound.StopAllSounds();
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        cursorScript.Lock();
        playerSound.ResumeSounds();
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }

    public void TriggerVictoryScreen()
    {
        isVictoryActive = true;
        playerSound.StopAllSounds();

        Time.timeScale = 0f;
        cursorScript.Unlock();
        victoryScreen.SetActive(true);
        victoryScreen.GetComponent<PopulateVictoryPanel>().CalculateRank();
        victoryScreen.GetComponent<PopulateVictoryPanel>().DisplayTime();
    }

    public void RestartButton()
    {
        isVictoryActive = false;
        playerSound.ResumeSounds();

        Time.timeScale = 1f;
        cursorScript.Lock();
        victoryScreen.SetActive(false);
        pauseMenu.SetActive(false);
        Destroy(GameObject.FindGameObjectWithTag("Player"));

        restartLevel.Raise();
    }

    public void NextLevelButton()
    {
        isVictoryActive = false;
        playerSound.ResumeSounds();

        Time.timeScale = 1f;
        cursorScript.Lock();
        victoryScreen.SetActive(false);

        nextLevel.Raise();
    }

    /// <summary>
    /// Activates the wrong colour prompt at the top of the screen, waits three seconds before returning it
    /// </summary>
    public void OnWrongColour()
    {
        wrongColourAnimator.SetBool("wrongColour", true);
        StartCoroutine(gameObject.CountDownFrom(3.0f, () => { ResetWrongColour(); }));
    }

    /// <summary>
    /// Activates the +10 prompt, waits 1 second before removing it
    /// </summary>
    public void OnAddTime()
    {
        plusTenAnimator.SetBool("+10", true);
        StartCoroutine(gameObject.CountDownFrom(1f, () => { ResetAddTime(); }));
    }

    /// <summary>
    /// Animates the +10 prompt away
    /// </summary>
    private void ResetAddTime()
    {
        plusTenAnimator.SetBool("+10", false);
    }

    /// <summary>
    /// Animates the wrong colour prompt away
    /// </summary>
    private void ResetWrongColour()
    {
        wrongColourAnimator.SetBool("wrongColour", false);
    }



    
}
