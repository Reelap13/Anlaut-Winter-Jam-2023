using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActivationPanelController : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;

    private Transform _tr;
    private Transform _cameraTr;
    private InteractiveObject _interactiveObject;
    private void Start()
    {
        _tr = GetComponent<Transform>();
        _cameraTr = Camera.main.GetComponent<Transform>();
    }

    private void Update()
    {
        if (_interactiveObject != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _interactiveObject.IsInteractive = false;
                _interactiveObject.Interact();
                _interactiveObject.DeleteActivationPanel();
            }
        }
    }

    public InteractiveObject InteractiveObject
    {
        set
        {
            _interactiveObject = value;
        }
    }
    private void FixedUpdate()
    {
        _tr.LookAt(_cameraTr);
    }

    public string Text
    {
        set
        {
            text.text = "E: " + value;
        }
        get
        {
            return text.text;
        }
    }
}
