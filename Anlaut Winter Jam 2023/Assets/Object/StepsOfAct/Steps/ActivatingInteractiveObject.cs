using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatingInteractiveObject : StepOfAct
{
    [SerializeField] private List<InteractiveObject> _interactiveObjs;
    public override void StartStep()
    {
        foreach(InteractiveObject obj in _interactiveObjs)
        {
            obj.IsInteractive = true;
        }
    }

    public override void FinishStep()
    {
        base.FinishStep();
    }
}
