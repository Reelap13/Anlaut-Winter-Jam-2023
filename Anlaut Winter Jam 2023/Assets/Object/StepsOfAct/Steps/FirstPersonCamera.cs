using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : StepOfAct
{
    public override void StartStep()
    {
        CameraController.Instance.ChangeStateToFirstPerson();
        FinishStep();
    }

    public override void FinishStep()
    {
        base.FinishStep();
    }
}

