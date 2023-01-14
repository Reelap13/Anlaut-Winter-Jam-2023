using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    Transform tr;
    private void Awake()
    {
        tr = GetComponent<Transform>();
    }

    public Transform Transform
    {
        private set
        {
            tr = value;
        }
        get
        {
            return tr;
        }
    }
}
