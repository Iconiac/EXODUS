using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class PortBase
{

    public static PortCtrl Dctrl;

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
    }

    public static void GetDialoge(List<string> keys, List<string> values)
    {
        for (int i = 0; i < keys.Count; i++)
        {
            dialoges.Add(keys[i], values[i]);
        }
    }
}
