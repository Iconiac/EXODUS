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
		if (questGiver != null && GetComponent<DialogueController>().questActive == true)
		{
			questGiver.GetComponent<DialogueController>().questCompleted = true;
			GetComponent<DialogueController>().questCompleted = true;
		}

		if (questTarget != null)
		{  
			if (GetComponent<DialogueController>().questCompleted == false)
			{
				GetComponent<DialogueController>().questActive = true;
				questTarget.GetComponent<DialogueController>().questActive = true;
			}

			if (GetComponent<DialogueController>().questActive == true)
			{
				if (GetComponent<DialogueController>().questCompleted == true)
				{
					questGoal.GetComponent<QuestComplete>().QuestEvent();
				}
			}
		}
	}

}
}
