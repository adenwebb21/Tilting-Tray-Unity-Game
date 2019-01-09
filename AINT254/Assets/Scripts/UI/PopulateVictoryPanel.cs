using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// Populates the victory screen that appears at the end of a level
/// </summary>
public class PopulateVictoryPanel : MonoBehaviour {

    [SerializeField]
    private Text rank, timer, highscore;

    [SerializeField]
    private FloatVariable timerObject;

    [SerializeField]
    private FloatVariable[] highScores;

    [SerializeField]
    private IntVariable currentLevel;

	public void CalculateRank()
    {
        rank.text = rank.text + "Not yet implemented";
    }

    /// <summary>
    /// Compares time to high score and displays the correct values
    /// </summary>
    public void DisplayTime()
    {
        if (timerObject.Value < highScores[currentLevel.Value].Value || highScores[currentLevel.Value].Value == 0)
        {
            highScores[currentLevel.Value].Value = timerObject.Value;
        }
        
        highscore.text = "Highscore: " + highScores[currentLevel.Value].Value.ToString("f1");
        timer.text = "Time: " + timerObject.Value.ToString("f1");
    }
}
