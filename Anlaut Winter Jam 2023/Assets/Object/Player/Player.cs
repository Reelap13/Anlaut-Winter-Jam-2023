using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    private Transform tr;
    private Animator anim;
    private bool isMove;
    private void Awake()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        isMove = true;
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

    public bool IsMove
    {
        set
        {
            isMove = value;
        }
        get
        {
            return isMove;
        }
    }
}
