using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private string _text;
    [SerializeField] private GameObject _activationPanelPref;


    private GameObject _activationPanel;

    public bool IsInteractive { get; set; } = false;


    public void CreateActivationPanel()
    {
        if (_activationPanel == null)
            _activationPanel = Instantiate(_activationPanelPref) as GameObject;
    }

    public void DeleteActivationPanel()
    {
        if (_activationPanel != null)
            Destroy(_activationPanel);
    }

}
