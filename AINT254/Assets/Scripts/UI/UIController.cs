using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ISS;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    private LockCursor cursorScript;

    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private IntVariable currentLevel;

    //[SerializeField]
    //private Timer timer;

    [SerializeField]
    private GameObject victoryScreen, levelInfo;

    [SerializeField]
    private Animator wrongColourAnimator, plusTenAnimator;

    [SerializeField]
    private GameEvent nextLevel, restartLevel;

    private PlayerSoundManager playerSound;

    private bool isVictoryActive = false;

    [SerializeField]
    private string[] levelInfos;

    private void Start()
    {       
        cursorScript = gameObject.GetComponent<LockCursor>();
        playerSound = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSoundManager>();
        Resume();
    }

    private void Update()
    {
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
        pauseMenu.SetActive(false);
        Destroy(GameObject.FindGameObjectWithTag("Player"));

        restartLevel.Raise();
    }

    public void ShowInfo()
    {
        if(currentLevel.Value < levelInfos.Length)
        {
            levelInfo.GetComponentInChildren<Text>().text = levelInfos[currentLevel.Value];
            levelInfo.SetActive(true);
            cursorScript.Unlock();
            playerSound.StopAllSounds();
            Time.timeScale = 0.0f;
        }      
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

    public void OnWrongColour()
    {
        wrongColourAnimator.SetBool("wrongColour", true);
        StartCoroutine(gameObject.CountDownFrom(3.0f, () => { ResetWrongColour(); }));
    }

    public void OnAddTime()
    {
        plusTenAnimator.SetBool("+10", true);
        StartCoroutine(gameObject.CountDownFrom(1f, () => { ResetAddTime(); }));
    }

    private void ResetAddTime()
    {
        plusTenAnimator.SetBool("+10", false);
    }

    private void ResetWrongColour()
    {
        wrongColourAnimator.SetBool("wrongColour", false);
    }



    
}
