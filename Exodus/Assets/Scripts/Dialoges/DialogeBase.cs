using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class DialogeBase
{
	public static DialogCtrl Dctrl;

	private static Dictionary<string, string> dialoges = new Dictionary<string, string>();
	

	public static void AddDialoge(string name, string text)
	{
		dialoges.Add(name, text);
	}

	public static void SetDialoge (int dialogeKey)
	{
		if (Animator.StringToHash("DialogeA") == dialogeKey)
		{
			Dctrl.DialogeText.text = dialoges["DialogeA"];
		}
		else if (Animator.StringToHash("DialogeB") == dialogeKey)
		{
			Dctrl.DialogeText.text = dialoges["DialogeB"];
            Dctrl.YesOption.SetActive(false);
            Dctrl.NoOption.SetActive(false);
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
	}

	public static void GetDialoge(List<string> keys, List<string> values)
	{
		for (int i = 0; i < keys.Count; i++) 
		{
			dialoges.Add(keys[i], values[i]);
		}
	}

}
