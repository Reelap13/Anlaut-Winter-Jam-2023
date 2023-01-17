using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogButtonController : MonoBehaviour
{
    [SerializeField] private DialogController dialog;
    [SerializeField] private float minTimeBetweenClicks;

    private float timeAfterClick = 0;


    private void Update()
    {
        timeAfterClick += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E))
            Click();
    }

    public void Click()
    {
        if (timeAfterClick >= minTimeBetweenClicks)
        {
            dialog.ShowToTheNextPassage();
            timeAfterClick = 0;
        }
    }
}
