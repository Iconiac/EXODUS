using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class DitchBase
{

    public static DitchCtrl Dctrl;

    private static Dictionary<string, string> dialoges = new Dictionary<string, string>();


    public static void AddDialoge(string name, string text)
    {
        dialoges.Add(name, text);
    }

    public static void SetDialoge(int dialogeKey)
    {
        if (Animator.StringToHash("DialogeA") == dialogeKey)
        {
            Dctrl.DialogeText.text = dialoges["DialogeA"];
        }
        else if (Animator.StringToHash("DialogeB") == dialogeKey)
        {
            Dctrl.DialogeText.text = dialoges["DialogeB"];
        }
        else if (Animator.StringToHash("DialogeC") == dialogeKey)
        {
            Dctrl.DialogeText.text = dialoges["DialogeC"];
        }
        else if (Animator.StringToHash("DialogeD") == dialogeKey)
        {
            Dctrl.DialogeText.text = dialoges["DialogeD"];
        }
        else if (Animator.StringToHash("DialogeE") == dialogeKey)
        {
            Dctrl.DialogeText.text = dialoges["DialogeE"];
        }
        else if (Animator.StringToHash("DialogeF") == dialogeKey)
        {
            Dctrl.DialogeText.text = dialoges["DialogeF"];
        }
        else if (Animator.StringToHash("DialogeG") == dialogeKey)
        {
            Dctrl.DialogeText.text = dialoges["DialogeG"];
        }
        else if (Animator.StringToHash("DialogeH") == dialogeKey)
        {
            Dctrl.DialogeText.text = dialoges["DialogeH"];
        }
        else if (Animator.StringToHash("DialogeI") == dialogeKey)
        {
            Dctrl.DialogeText.text = dialoges["DialogeI"];
        }
        else if (Animator.StringToHash("DialogeJ") == dialogeKey)
        {
            Dctrl.DialogeText.text = dialoges["DialogeJ"];
        }
        else if (Animator.StringToHash("DialogeK") == dialogeKey)
        {
            Dctrl.DialogeText.text = dialoges["DialogeK"];
        }
        else if (Animator.StringToHash("DialogeL") == dialogeKey)
        {
            Dctrl.DialogeText.text = dialoges["DialogeL"];
        }
        else if (Animator.StringToHash("DialogeM") == dialogeKey)
        {
            Dctrl.DialogeText.text = dialoges["DialogeM"];
        }
        else if (Animator.StringToHash("DialogeN") == dialogeKey)
        {
            Dctrl.DialogeText.text = dialoges["DialogeN"];
        }
        else if (Animator.StringToHash("DialogeO") == dialogeKey)
        {
            Dctrl.DialogeText.text = dialoges["DialogeO"];
        }
        else if (Animator.StringToHash("DialogeP") == dialogeKey)
        {
            Dctrl.DialogeText.text = dialoges["DialogeP"];
        }
        else if (Animator.StringToHash("DialogeQ") == dialogeKey)
        {
            Dctrl.DialogeText.text = dialoges["DialogeQ"];
        }
        else if (Animator.StringToHash("DialogeR") == dialogeKey)
        {
            Dctrl.DialogeText.text = dialoges["DialogeR"];
        }
    }

    public static void GetDialoge(List<string> keys, List<string> values)
    {
        for (int i = 0; i < keys.Count; i++)
        {
            dialoges.Add(keys[i], values[i]);
        }
    }
}
