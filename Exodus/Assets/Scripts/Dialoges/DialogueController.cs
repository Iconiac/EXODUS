using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueController : MonoBehaviour 
{
	[SerializeField] string BeforeQuest;
	[SerializeField] string QuestEnding;
    [SerializeField] Text _displayQuest;
	[SerializeField] AudioSource BeginningSound;
	[SerializeField] AudioSource DuringSound;
	[SerializeField] AudioSource EndSound;

    public string DuringQuest;
	

		public void ShowDialogue()
		{
            
			if (GetComponent<QuestController>().QuestCompleted == false && GetComponent<QuestController>().QuestActive == false)
			{ 
				_displayQuest.text = "" + BeforeQuest;
			BeginningSound.Play ();
			}
	
			if(GetComponent<QuestController>().QuestActive == true && GetComponent<QuestController>().QuestCompleted == false)
			{
				_displayQuest.text = "" + DuringQuest;
			DuringSound.Play();
			}
			if (GetComponent<QuestController>().QuestCompleted == true)
			{
				_displayQuest.text = "" + QuestEnding;
			EndSound.Play ();
			}
		}
	
		void ResetText()
		{
			_displayQuest.text = "";
		}
	}
