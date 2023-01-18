using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act : MonoBehaviour
{
    [SerializeField] private Transform _startPlayerPosition;
    [SerializeField] private List<StepOfAct> _steps;
    [SerializeField] private string _nameOfTheNextAct;

    private StepOfAct _currentStep;
    private int _indexOfCurrentStep;

    public void StartAct()
    {
        _indexOfCurrentStep = -1;
        GoToTheNextStep();
    }

    public void GoToTheNextStep()
    {
        StartCoroutine(StartNextStepWithDelay());
    }

    public void FinishAct()
    {
        GameController.Instance.GoToTheNextAct(_nameOfTheNextAct);
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

    private IEnumerator StartNextStepWithDelay()
    {
        yield return new WaitForSeconds(0.3f);

       ++_indexOfCurrentStep;
        Debug.Log($"Step {_indexOfCurrentStep} was started");
        if (_indexOfCurrentStep >= _steps.Count)
        {
            FinishAct();
        }
        else
        {
            _currentStep = _steps[_indexOfCurrentStep];
            _currentStep.StartStep();
        }
    }
}
