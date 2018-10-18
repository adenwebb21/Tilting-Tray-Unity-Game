using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTrayObj : MonoBehaviour
{
    private Transform itemTransform;
    public GameObject scoreManager;

    void Start()
    {
        itemTransform = transform;
    }

    private void Update()
    {
        if(itemTransform.position.y <= 0.1)
        {
            gameObject.SetActive(false);
        }
    }
}
