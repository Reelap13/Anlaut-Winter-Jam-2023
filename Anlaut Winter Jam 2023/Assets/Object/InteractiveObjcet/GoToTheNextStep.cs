using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTheNextStep : InteractiveObject
{
    public override void Interact()
    {
        GameController.Instance.Act.Step.FinishStep();
    }
}
