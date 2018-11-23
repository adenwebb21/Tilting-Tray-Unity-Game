using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockCursor : MonoBehaviour {

    private CursorLockMode lockedMode = CursorLockMode.Locked;
    private CursorLockMode unlockedMode = CursorLockMode.None;
	// Use this for initialization
	void Start () {

        Cursor.lockState = lockedMode;
        Cursor.visible = false;

	}

    public void Unlock()
    {
        Cursor.lockState = unlockedMode;
        Cursor.visible = true;
    }

    public void Lock()
    {
        Cursor.lockState = lockedMode;
        Cursor.visible = false;
    }
}
