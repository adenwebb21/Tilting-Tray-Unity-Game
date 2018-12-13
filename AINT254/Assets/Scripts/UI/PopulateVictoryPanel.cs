using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PopulateVictoryPanel : MonoBehaviour {

    [SerializeField]
    private Text rank, timer, highscore;

    [SerializeField]
    private FloatVariable timerObject, highScore;

	public void CalculateRank()
    {
        rank.text = rank.text + "Not yet implemented";
    }

    public void DisplayTime()
    {
        if (timerObject.Value < highScore.Value || highScore.Value == 0)
        {
            highScore.Value = timerObject.Value;
        }
        
        highscore.text += highScore.Value.ToString("f1");
        timer.text += timerObject.Value.ToString("f1");
    }
}
