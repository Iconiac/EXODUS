using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueController : MonoBehaviour 
{
	public string beforeQuest;
	public string questGoodEnding;
	public string duringQuest;
	public string storyText;
	public bool questCompleted;
	public bool questActive;

	private Text displayQuest;

	void Start()
	{
		displayQuest = GameObject.Find ("InGameText").GetComponent<Text> ();
		displayQuest.text = "Los jetzt, raus hier! Hier lang!";
		Invoke ("ResetText", 4f);
	}

	public void ShowDialogue()
	{
		if (questCompleted == false && questActive == false)
		{ 
			displayQuest.text = "" + beforeQuest;
		}

		if(questActive == true)
		{
			displayQuest.text = "" + duringQuest;
		}
		if (questCompleted == true)
		{
			displayQuest.text = "" + questGoodEnding;
		}

		if (displayQuest.text != "")
		{
			Invoke ("ResetText", 4f);
		}
	}

	public void StoryText()
	{
		displayQuest.text = "" + storyText;
		Invoke ("ResetText", 4f);
	}

	void ResetText()
	{
		displayQuest.text = "";
	}
}
