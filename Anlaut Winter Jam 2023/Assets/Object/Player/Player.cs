using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    Transform tr;
    Animator anim;
    private void Awake()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
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

    public Animator Animator
    {
        private set
        {
            anim = value;
        }
        get
        {
            return anim;
        }
    }
}
