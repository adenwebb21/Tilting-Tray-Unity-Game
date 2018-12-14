using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    private LockCursor cursorScript;

    [SerializeField]
    private GameObject pauseMenu;

    //[SerializeField]
    //private Timer timer;

    [SerializeField]
    private GameObject victoryScreen;

    private PlayerSoundManager playerSound;

    private bool isVictoryActive = false;

    private void Start()
    {       
        cursorScript = gameObject.GetComponent<LockCursor>();
        playerSound = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSoundManager>();
        Resume();
    }

    private void Update()
    {
        if(playerSound == null)
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
        //timer.StopTimer();
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

        SceneManager.LoadScene("Labyrinth");
    }

    
}
