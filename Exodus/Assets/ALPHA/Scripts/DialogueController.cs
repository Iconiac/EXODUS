using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueController : MonoBehaviour 
{
	[SerializeField] string BeforeQuest;
	[SerializeField] string QuestEnding;
	[SerializeField] string StoryText;
	[SerializeField] string UniquePlayerText;

	public string DuringQuest;
	public bool QuestCompleted;
	public bool QuestActive;

	private Text _displayQuest;

	void Awake()
	{
		_displayQuest = GameObject.Find ("InGameText").GetComponent<Text> ();

		if (UniquePlayerText != "")
		{
			_displayQuest.text = "" + UniquePlayerText;
		}
	}

	public void ShowDialogue()
	{
		if (QuestCompleted == false && QuestActive == false)
		{ 
			_displayQuest.text = "" + BeforeQuest;
		}

		if(QuestActive == true)
		{
			_displayQuest.text = "" + DuringQuest;
		}
		if (QuestCompleted == true)
		{
			_displayQuest.text = "" + QuestEnding;
		}
	}

	public void Story()
	{
		_displayQuest.text = "" + StoryText;
		Invoke ("ResetText", 4f);
	}

	void ResetText()
	{
		_displayQuest.text = "";
	}
}
