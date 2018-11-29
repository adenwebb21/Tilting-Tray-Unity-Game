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

    private bool isVictoryActive = false;

    private void Start()
    {
        cursorScript = gameObject.GetComponent<LockCursor>();
    }

    private void Update()
    {
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
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        cursorScript.Lock();
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }

    public void TriggerVictoryScreen()
    {
        isVictoryActive = true;

        Time.timeScale = 0f;
        timer.StopTimer();
        VictoryScreen.SetActive(true);
        VictoryScreen.GetComponent<PopulateVictoryPanel>().CalculateRank();
        VictoryScreen.GetComponent<PopulateVictoryPanel>().DisplayTime();
    }

    
}
