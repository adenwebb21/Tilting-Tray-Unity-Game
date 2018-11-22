using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField]
    private int score;

    private string scoreString = "Score: ";
    private GUIStyle style = new GUIStyle();

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 100), scoreString + score.ToString(), style);
    }

    void Start()
    {
        style.fontSize = 40;
        style.normal.textColor = Color.white;

        score = GameObject.FindGameObjectsWithTag("TrayItems").Length;
    }

    public void ReduceScore()
    {
        if(score > 0)
        {
            score--;
        }
    }

    public void SetScore(int newScore)
    {
        score = newScore;
    }
}
