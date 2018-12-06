using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    private LockCursor cursorScript;
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private Timer timer;
    [SerializeField]
    private GameObject VictoryScreen;

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
        timer.StopTimer();
        VictoryScreen.SetActive(true);
        VictoryScreen.GetComponent<PopulateVictoryPanel>().CalculateRank();
        VictoryScreen.GetComponent<PopulateVictoryPanel>().DisplayTime();
    }

    public void RestartButton()
    {
        isVictoryActive = false;
        playerSound.ResumeSounds();

        Time.timeScale = 1f;
        cursorScript.Lock();
        VictoryScreen.SetActive(false);

        SceneManager.LoadScene("Labyrinth");
    }

    
}
