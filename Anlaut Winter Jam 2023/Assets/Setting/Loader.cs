using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    private void Awake()
    {
        LockedMouse();
    }

    private void LockedMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
