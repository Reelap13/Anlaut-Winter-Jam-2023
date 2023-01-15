using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private string _text;
    [SerializeField] private GameObject _activationPanelPref;

    private Transform tr;
    private GameObject _activationPanel;

    public bool IsInteractive { get; set; } = false;

    private void Start()
    {
        tr = GetComponent<Transform>();
    }

    public abstract void Interact();

    public void CreateActivationPanel()
    {
        if (_activationPanel == null)
        {
            _activationPanel = Instantiate(_activationPanelPref) as GameObject;
            _activationPanel.transform.parent = tr;
            _activationPanel.transform.position = tr.position + new Vector3(0, 10, 0);
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
}
