using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTrayObj : MonoBehaviour
{
    private Transform itemTransform;
    private GameObject scoreKeeper;

    void Start()
    {
        scoreKeeper = GameObject.FindGameObjectWithTag("ScoreKeeper");
        itemTransform = transform;
    }

    private void Update()
    {
        if(itemTransform.position.y <= 0.2)
        {
            scoreKeeper.GetComponent<ScoreKeeper>().ReduceScore();
            Destroy(gameObject);
        }
    }
}
