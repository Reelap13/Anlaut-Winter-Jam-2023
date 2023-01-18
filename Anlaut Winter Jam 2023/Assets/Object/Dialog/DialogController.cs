using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogController : Singleton<DialogController>
{
    [SerializeField] private GameObject dialogWindow;
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private DialogImageController image;
    [SerializeField] private DialogAudioController audio;

    private List<Passage> passages;
    private Passage passage;
    private int indexOfPassage;

    public void StartDialog(List<ParticipantsOfDialog> participants, List<Passage> passages)
    {
        dialogWindow.SetActive(true);
        audio.Participants = participants;
        this.passages = passages;
        
        LoadStartInfo();
        ShowToTheNextPassage();
    }

    public void ShowToTheNextPassage()
    {
        if (indexOfPassage >= 0)
        {
            audio.StopMakingSound(passage.Author);
            StopAllCoroutines();
            text.text = "";
            Debug.Log("Stop");
        }

        ++indexOfPassage;
        if (indexOfPassage >= passages.Count)
        {
            FinishDialog();
            return;
        }
        passage = passages[indexOfPassage];

        if (passage.Author != null)
            image.ChangeImage(passage.Author);
        if (passage.Text != null)
            StartCoroutine(SpawnSentence(passage.Text));
    }

    IEnumerator SpawnSentence(string sentence)
    {
        if (passage.Clip != null)
            audio.MakeSound(passage.Author, passage.Clip);
        text.text = "";
        foreach (char letter in sentence)
        {
            text.text += letter;
            yield return new WaitForSeconds(0.02f);
        }

        if (passage.Clip != null)
            audio.StopMakingSound(passage.Author);
    }

    private void LoadStartInfo()
    {
        indexOfPassage = -1;
    }


    private void FinishDialog()
    {
        dialogWindow.SetActive(false);
        GameController.Instance.Act.Step.FinishStep();
    }
}
