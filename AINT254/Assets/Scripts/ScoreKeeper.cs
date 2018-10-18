using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public int score;

    private string scoreString = "Score: ";
    private GUIStyle style = new GUIStyle();

    private void OnGUI()
    {
        style.fontSize = 40;
        style.normal.textColor = Color.white;
        GUI.Label(new Rect(10, 10, 100, 100), scoreString, style);
    }

    void Start()
    {
        score = GameObject.FindGameObjectsWithTag("TrayItems").Length;
        scoreString += score.ToString();
    }

    void Update()
    {

    }

    public void ReduceScore()
    {
        if(score > 0)
        {
            score--;
        }
    }
}
