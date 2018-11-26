using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour {

    private bool isBeingDestroyed = false;
    private float t = 0;

    public void DestroyThisPlayer()
    {
        gameObject.tag = "DeadPlayer";
        isBeingDestroyed = true;
        Destroy(gameObject, 1f);
    }

    private void Update()
    {
        if(isBeingDestroyed)
        {
            gameObject.GetComponent<Renderer>().material.SetFloat("_Amount", Mathf.Lerp(0, 1, t));
            t += 0.5f * Time.deltaTime;
        }
    }
}
