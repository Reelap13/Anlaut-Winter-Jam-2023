using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformingPartOfStep : InteractiveObject
{
    public override void Interact()
    {
        GameController.Instance.Act.Step.PerformPartOfStep();
    }
}
