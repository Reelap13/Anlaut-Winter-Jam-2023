using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseEyes : StepOfAct
{
    public override void StartStep()
    {
        GameController.Instance.Act.GoToTheNextStep();
    }
}
