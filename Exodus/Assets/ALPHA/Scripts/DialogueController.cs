using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	public class DialogueController : MonoBehaviour 
	{
		[SerializeField] string BeforeQuest;
		[SerializeField] string QuestEnding;
		[SerializeField] string StoryText;
		[SerializeField] string UniquePlayerText;
	
		public string DuringQuest;
	
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
}
