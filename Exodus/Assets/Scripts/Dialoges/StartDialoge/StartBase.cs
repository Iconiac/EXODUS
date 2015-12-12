using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class StartBase
{
    public static StartCtrl Dctrl;

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
    }

    public static void GetDialoge(List<string> keys, List<string> values)
    {
        for (int i = 0; i < keys.Count; i++)
        {
            dialoges.Add(keys[i], values[i]);
        }
    }
}
