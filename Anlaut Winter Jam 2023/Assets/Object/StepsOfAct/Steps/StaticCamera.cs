using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCamera : StepOfAct
{
    [SerializeField] private Transform _point;
    public override void StartStep()
    {
        CameraController.Instance.ChangeStateToStatic(_point);
        FinishStep();
    }

    public override void FinishStep()
    {
        base.FinishStep();
    }
}
