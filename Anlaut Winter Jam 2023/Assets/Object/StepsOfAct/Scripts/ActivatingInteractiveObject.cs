using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatingInteractiveObject : StepOfAct
{
    [SerializeField] private List<InteractiveObject> _interactiveObjs;
    private int _countOfIntObj;
    public override void StartStep()
    {
        foreach(InteractiveObject obj in _interactiveObjs)
        {
            obj.IsInteractive = true;
        }
        _countOfIntObj = _interactiveObjs.Count;
    }

    public override void PerformPartOfStep()
    {
        --_countOfIntObj;
        if (_countOfIntObj == 0)
            FinishStep();
        base.PerformPartOfStep();
    }

    public override void FinishStep()
    {
        base.FinishStep();
    }
}
