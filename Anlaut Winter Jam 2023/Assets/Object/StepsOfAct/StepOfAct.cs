using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StepOfAct : MonoBehaviour
{
    public abstract void StartStep();
    public virtual void PerformPartOfStep()
    {
        Debug.Log("Part of the stap was performed");
    }
    public virtual void FinishStep()
    {
        GameController.Instance.Act.GoToTheNextStep();
    }
}
