using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueController : MonoBehaviour 
{
	[SerializeField] string BeforeQuest;
	[SerializeField] string QuestEnding;
    [SerializeField] Text DisplayQuest;
	[SerializeField] AudioSource BeginningSound;
	[SerializeField] AudioSource DuringSound;
	[SerializeField] AudioSource EndSound;

    public string DuringQuest;
	

		public void ShowDialogue()
		{
            
			if (GetComponent<QuestController>().QuestCompleted == false && GetComponent<QuestController>().QuestActive == false)
			{ 
				DisplayQuest.text = "" + BeforeQuest;
				BeginningSound.Play ();
			}
	
			if(GetComponent<QuestController>().QuestActive == true && GetComponent<QuestController>().QuestCompleted == false)
			{
				DisplayQuest.text = "" + DuringQuest;
				DuringSound.Play();
			}
			if (GetComponent<QuestController>().QuestCompleted == true)
			{
				DisplayQuest.text = "" + QuestEnding;
				EndSound.Play ();
			}
		}
	
		void ResetText()
		{
			DisplayQuest.text = "";
		}
	}
