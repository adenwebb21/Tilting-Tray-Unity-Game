using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour {

    [SerializeField]
    private GameObject victoryPanel;

    [SerializeField]
    private Timer timer;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0f;
            timer.StopTimer();
            victoryPanel.SetActive(true);
            victoryPanel.GetComponent<PopulateVictoryPanel>().CalculateRank();
            victoryPanel.GetComponent<PopulateVictoryPanel>().DisplayTime();
        }
    }
}
