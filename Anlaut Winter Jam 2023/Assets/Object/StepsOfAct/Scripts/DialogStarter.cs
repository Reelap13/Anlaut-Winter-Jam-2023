using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogStarter : StepOfAct
{
    [SerializeField] private List<ParticipantsOfDialog> participants;
    [SerializeField] private List<Passage> passages;

    public override void StartStep()
    {
        DialogController.Instance.StartDialog(participants, passages);
    }

    public override void FinishStep()
    {
        base.FinishStep();
    }
}
