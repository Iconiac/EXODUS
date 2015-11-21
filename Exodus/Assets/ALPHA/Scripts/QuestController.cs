using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
public class QuestController : MonoBehaviour 
{
	public GameObject questGiver;
	public GameObject questTarget;
	public GameObject questGoal;

	public void QuestEvent()
	{
		if (questGiver != null && GetComponent<DialogueController>().QuestActive == true)
		{
			questGiver.GetComponent<DialogueController>().QuestCompleted = true;
			GetComponent<DialogueController>().QuestCompleted = true;
		}

		if (questTarget != null)
		{  
			if (GetComponent<DialogueController>().QuestCompleted == false)
			{
				GetComponent<DialogueController>().QuestActive = true;
				questTarget.GetComponent<DialogueController>().QuestActive = true;
			}

			if (GetComponent<DialogueController>().QuestActive == true)
			{
				if (GetComponent<DialogueController>().QuestCompleted == true)
				{
					questGoal.GetComponent<QuestComplete>().QuestEvent();
				}
			}
		}
	}

}
}
