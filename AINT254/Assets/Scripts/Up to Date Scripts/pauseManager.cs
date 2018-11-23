using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseManager : MonoBehaviour {

    [SerializeField]
    private GameObject pauseMenu, tray;

    [SerializeField]
    private LockCursor cursorLockScript;

    [SerializeField]
    private Text text;

    private string winText = "Your score is: ";
    private string pauseText = "Paused";

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseMenu.activeSelf)
            {
                Resume();               
            }
            else
            {
                Pause();               
            }
        }
    }

    public void Pause()
    {
        cursorLockScript.Unlock();
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
        tray.GetComponent<TrayCheckpointMovement>().enabled = false;
        text.text = pauseText;
    }

    public void Resume()
    {
        cursorLockScript.Lock();
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        tray.GetComponent<TrayCheckpointMovement>().enabled = true;
    }

    public void ShowWinScreen()
    {
        Pause();
        text.text = winText + gameObject.GetComponent<ScoreKeeper>().score;
    }
}
