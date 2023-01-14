using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act : MonoBehaviour
{
    [SerializeField] private Transform _startPlayerPosition;
    [SerializeField] private List<StepOfAct> _steps;
    [SerializeField] private string nameOfTheNextAct;

    private StepOfAct _currentStep;
    private int _indexOfCurrentStep;

    public void StartAct()
    {
        _indexOfCurrentStep = -1;
        GoToTheNextStep();
    }

    public void GoToTheNextStep()
    {
        ++_indexOfCurrentStep;
        if (_indexOfCurrentStep >= _steps.Count)
        {
            FinishAct();
        }

        _currentStep = _steps[_indexOfCurrentStep];
        _currentStep.StartStep();
    }

    public void FinishAct()
    {
        GameController.Instance.GoToTheNextAct(nameOfTheNextAct);
    }

    public StepOfAct Step
    {
        get
        {
            return _currentStep;
        }
    }

    public Vector3 StartPlayerPosition
    {
        get
        {
            return _startPlayerPosition.position;
        }
    }
}
