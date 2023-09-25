using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    [SerializeField] PlayerController player;

    [SerializeField] GameObject dialogPanel;
    [SerializeField] TMP_Text dialogText;
    [SerializeField] List<string> dialogs;

    public int dialogIndex = 0;

    private void Start()
    {
        dialogs.Clear();
    }

    public void OpenDialog()
    {
        dialogPanel.SetActive(true);
        dialogText.text = dialogs[dialogIndex];
        dialogIndex++;

    }

    public void NextDialog()
    {
        if (dialogIndex >= dialogs.Count) 
        {
            CloseDialog();
        }
        else
        {
            dialogText.text = dialogs[dialogIndex];
            dialogIndex++;
        }

    }

    public void CloseDialog()
    {
        dialogPanel.SetActive(false);
        dialogIndex = 0;
        player.isTalking = false;
    }

    public void LoadDialogs(List<string> dialogsToLoad)
    {
        dialogs.Clear();
        dialogs.AddRange(dialogsToLoad);
    }
}
