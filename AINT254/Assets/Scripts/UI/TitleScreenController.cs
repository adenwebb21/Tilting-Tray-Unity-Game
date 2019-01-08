using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenController : MonoBehaviour {

    [SerializeField]
    private GameObject mainTitle, levelSelect;

    [SerializeField]
    private Sprite lvl1, lvl2, lvl3, lvl4;

    [SerializeField]
    private Image levelPreview;

    [SerializeField]
    private IntVariable startingLevel;

	public void LoadMainGame(int lvl)
    {
        SceneManager.LoadScene("Labyrinth");
        startingLevel.Value = lvl;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SwapMenuScreen()
    {
        mainTitle.SetActive(!mainTitle.activeInHierarchy);
        levelSelect.SetActive(!levelSelect.activeInHierarchy);
    }

    public void SetImagePreview(int level)
    {
        switch(level)
        {
            case 1:
                levelPreview.sprite = lvl1;
                break;
            case 2:
                levelPreview.sprite = lvl2;
                break;
            case 3:
                levelPreview.sprite = lvl3;
                break;
            case 4:
                levelPreview.sprite = lvl4;
                break;
            default:
                break;
        }
    }
}
