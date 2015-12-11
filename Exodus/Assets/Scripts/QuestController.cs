using UnityEngine;
using UnityEngine.UI;
using System.Collections;

	public class QuestController : MonoBehaviour 
	{
		public GameObject questGiver;
		public GameObject questTarget;
		public GameObject questGoal;
		public bool QuestCompleted;
		public bool QuestActive;
	
		public void QuestEvent()
		{
			if (questGiver != null && QuestActive == true)
			{
				questGiver.GetComponent<QuestController>().QuestCompleted = true;
				QuestCompleted = true;
			}
	
			if (questTarget != null)
			{  
				if (QuestCompleted == false)
				{
					QuestActive = true;
					questTarget.GetComponent<QuestController>().QuestActive = true;
				}
	
				if (QuestActive == true)
				{
					if (QuestCompleted == true)
					{
						questGoal.GetComponent<QuestComplete>().QuestEvent();
					}
				}
			}
		}
	
	}

