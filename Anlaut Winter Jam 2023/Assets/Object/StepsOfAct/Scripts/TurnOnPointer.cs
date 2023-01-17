using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnPointer : StepOfAct
{
    public override void StartStep()
    {
        GameController.Instance.Act.GoToTheNextStep();
    }
}
