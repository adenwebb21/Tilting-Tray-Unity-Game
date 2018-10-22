﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetController : MonoBehaviour {

    private Vector3 startLocation;

    private void Start()
    {
        startLocation = transform.position;
    }

    public void ResetPlayer()
    {
        transform.position = startLocation;
    }

}