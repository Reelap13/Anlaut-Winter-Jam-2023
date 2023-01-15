using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachingActivation: MonoBehaviour
{
    [SerializeField] private float _radius;

    private InteractiveObject obj;
    private Transform tr;

    private void Start()
    {
        obj = GetComponent<InteractiveObject>();
        tr = GetComponent<Transform>();
    }

    private void Update()
    {
        if (obj.IsInteractive)
        {
            if (CheckDistance())
                obj.CreateActivationPanel();
            else
                obj.DeleteActivationPanel();
        }
    }

    private bool CheckDistance()
    {
        return GetDirectionToThePlayer().magnitude <= _radius;
    }

    private Vector3 GetDirectionToThePlayer()
    {
        return Player.Instance.Transform.position - tr.position;
    }

}
