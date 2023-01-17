using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEyes : StepOfAct
{
    public override void StartStep()
    {
        GameController.Instance.Act.GoToTheNextStep();
    }
}
