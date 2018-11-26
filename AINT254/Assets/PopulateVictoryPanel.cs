using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PopulateVictoryPanel : MonoBehaviour {

    [SerializeField]
    private Text rank, timer;

    [SerializeField]
    private FloatVariable timerObject;

	public void CalculateRank()
    {
        rank.text = rank.text + "Not yet implemented";
    }

    public void DisplayTime()
    {
        timer.text += timerObject.Value.ToString("f1");
    }
}
