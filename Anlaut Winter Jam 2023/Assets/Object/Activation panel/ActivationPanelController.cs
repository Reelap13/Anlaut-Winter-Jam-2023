using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationPanelController : MonoBehaviour
{
    private Transform _tr;
    private Transform _cameraTr;
    private InteractiveObject _interactiveObject;
    private void Start()
    {
        _tr = GetComponent<Transform>();
        _cameraTr = Camera.main.GetComponent<Transform>();
        _interactiveObject = (_tr.parent).GetComponent<InteractiveObject>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _interactiveObject.IsInteractive = false;
            _interactiveObject.Interact();
            _interactiveObject.DeleteActivationPanel();
        }
    }

    private void FixedUpdate()
    {
        _tr.LookAt(_cameraTr);
    }
}
