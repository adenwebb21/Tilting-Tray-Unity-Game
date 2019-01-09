using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour {

    public void DestroyThisPlayer()
    {
        gameObject.tag = "DeadPlayer";
        Destroy(gameObject, 1f);
    }
}
