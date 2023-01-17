using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporSmthToPlace : StepOfAct
{
    [SerializeField] private Transform obj;
    [SerializeField] private Transform point;

    public override void StartStep()
    {
        obj.position = point.position;
        obj.rotation = point.rotation;
        FinishStep();
    }
}

