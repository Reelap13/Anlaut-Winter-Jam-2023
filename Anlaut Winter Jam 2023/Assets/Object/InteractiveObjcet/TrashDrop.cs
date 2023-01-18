using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDrop : InteractiveObject
{
    public override void Interact()
    {
        GameController.Instance.Act.Step.PerformPartOfStep();
        Destroy(gameObject);
    }
}
