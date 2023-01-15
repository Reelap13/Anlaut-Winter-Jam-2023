using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogController : MonoBehaviour
{
    [SerializeField] private GameObject dialogWindow;
    [SerializeField] private TextMeshPro text;

    private List<ParticipantsOfDialog> participants;

    public void StartDialog(List<ParticipantsOfDialog> participants)
    {
        this.participants = participants;
    }




    public void FinishDialog()
    {
        GameController.Instance.Act.Step.FinishStep();
    }
}
