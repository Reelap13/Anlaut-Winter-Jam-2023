using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    private List<ParticipantsOfDialog> participants;

    public void MakeSound(string name, AudioClip clip)
    {
        ParticipantsOfDialog participant = GetParticipantsByName(name);

        if (participant == null)
        {
            Debug.Log("Unknown participant of dialog");
            return;
        }

        participant.MakeSound(clip);
    }

    public void StopMakingSound(string name)
    {
        ParticipantsOfDialog participant = GetParticipantsByName(name);

        if (participant == null)
        {
            Debug.Log("Unknown participant of dialog");
            return;
        }

        participant.StopMakingSound();
    }

    public List<ParticipantsOfDialog> Participants
    {
        set
        {
            participants = value;
        }
    }

    private ParticipantsOfDialog GetParticipantsByName(string name)
    {
        Debug.Log(participants.Count);
        foreach (ParticipantsOfDialog participant in participants)
        {
            Debug.Log(participant.name + " " + participant.name.Length);
            Debug.Log(name + " " + name.Length);
            if (participant.name == name)
                return participant;
        }

        return null;
    }
}
