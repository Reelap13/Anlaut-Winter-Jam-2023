using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private string _text;
    [SerializeField] private GameObject _activationPanelPref;
    [SerializeField] private Transform _activationPanelPoition;

    private Transform tr;
    private GameObject _activationPanel;
    private Outline outline;

    private bool isInteractive = false;

    private void Start()
    {
        tr = GetComponent<Transform>();
        outline = GetComponent<Outline>();

        outline.OutlineWidth = 8f;
        outline.OutlineColor = new Color(1, 0.4f, 0, 1);
    }

    public abstract void Interact();

    public void CreateActivationPanel()
    {
        if (_activationPanel == null)
        {
            _activationPanel = Instantiate(_activationPanelPref) as GameObject;
            _activationPanel.transform.position = _activationPanelPoition.position;
            _activationPanel.GetComponent<ActivationPanelController>().InteractiveObject = this;
            _activationPanel.GetComponent<ActivationPanelController>().Text = _text;
        }
    }

    public void DeleteActivationPanel()
    {
        if (_activationPanel != null)
            Destroy(_activationPanel);
    }

    public void DestroyInteractiveObject()
    {
        Destroy(gameObject);
    }
    public bool IsInteractive
    {
        set
        {
            isInteractive = value;
            outline.enabled = isInteractive;
        }
        get
        {
            return isInteractive;
        }
    }
}
