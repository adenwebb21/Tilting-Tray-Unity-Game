using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour {

	public void LoadMainGame()
    {
        SceneManager.LoadScene("Labyrinth");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
