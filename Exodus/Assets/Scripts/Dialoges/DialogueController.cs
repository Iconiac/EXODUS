using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueController : MonoBehaviour 
{
	[SerializeField] string BeforeQuest;
	[SerializeField] string QuestEnding;
	[SerializeField] string StoryText;
	[SerializeField] string UniquePlayerText;
    [SerializeField] Text _displayQuest;

    public string DuringQuest;
	
		
	
		void Awake()
		{
	
			if (UniquePlayerText != "")
			{
				_displayQuest.text = "" + UniquePlayerText;
			}
		}
	
		public void ShowDialogue()
		{
            
			if (GetComponent<QuestController>().QuestCompleted == false && GetComponent<QuestController>().QuestActive == false)
			{ 
				_displayQuest.text = "" + BeforeQuest;
			}
	
			if(GetComponent<QuestController>().QuestActive == true)
			{
				_displayQuest.text = "" + DuringQuest;
			}
			if (GetComponent<QuestController>().QuestCompleted == true)
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
