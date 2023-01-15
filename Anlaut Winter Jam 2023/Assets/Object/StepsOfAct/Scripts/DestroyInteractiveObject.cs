using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInteractiveObject : StepOfAct
{
    [SerializeField] private List<InteractiveObject> _interactiveObjs;
    public override void StartStep()
    {
        foreach (InteractiveObject obj in _interactiveObjs)
        {
            obj.DestroyInteractiveObject();
        }
        FinishStep();
    }

    public override void FinishStep()
    {
        base.FinishStep();
    }
}

