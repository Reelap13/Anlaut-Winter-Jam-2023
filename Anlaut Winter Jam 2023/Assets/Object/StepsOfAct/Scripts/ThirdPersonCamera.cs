using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : StepOfAct
{
    public override void StartStep()
    {
        CameraController.Instance.ChangeStateToThirdPerson();
        FinishStep();
    }

    public override void FinishStep()
    {
        base.FinishStep();
    }
}
