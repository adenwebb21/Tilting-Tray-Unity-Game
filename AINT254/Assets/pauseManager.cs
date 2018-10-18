using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseManager : MonoBehaviour {

    private GameObject pauseMenu;
    public GameObject tray;

    private void Start()
    {
        pauseMenu = GameObject.FindGameObjectWithTag("ShowOnPause");
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseMenu.active)
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
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
        tray.GetComponent<FirstPersonTrayControls>().enabled = false;
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        tray.GetComponent<FirstPersonTrayControls>().enabled = true;
    }
}
