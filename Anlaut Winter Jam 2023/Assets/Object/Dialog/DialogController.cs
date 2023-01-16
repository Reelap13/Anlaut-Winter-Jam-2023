using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogController : Singleton<DialogController>
{
    [SerializeField] private GameObject dialogWindow;
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private ImageController image;
    [SerializeField] private AudioController audio;

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
            StopCoroutine("SpawnSentence");
            text.text = "";
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
        if (passage.Clip != null)
            audio.MakeSound(passage.Author, passage.Clip);
        if (passage.Text != null)
            StartCoroutine(SpawnSentence(passage.Text));
    }

    IEnumerator SpawnSentence(string sentence)
    {
        text.text = "";
        foreach (char letter in sentence)
        {
            text.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
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
