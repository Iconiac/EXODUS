using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	public class TeddyDialoge : MonoBehaviour 
	{
		[SerializeField] string FirstEnter;
		[SerializeField] string SecondEnter; 
	
		private GameObject _target;
		private Text _inGameText;

		void Start()
		{
			_target = GetComponent<QuestController>().questTarget;
			_inGameText = GameObject.Find ("InGameText").GetComponent<Text>();
		}
	
		void OnTriggerEnter(Collider col)
		{
			if (col.gameObject.name == "Player")
			{
				if (GetComponent<QuestController>().QuestCompleted == false)
				{
					_inGameText.text = "" + FirstEnter;
					_target.SetActive(true);
					_target.GetComponent<QuestController>().QuestActive = true;
				}

				if (GetComponent<QuestController>().QuestCompleted == true)
				{
					StartCoroutine("QuestDone");
				}
			}
		}

		IEnumerator QuestDone()
		{
			_inGameText.text = "" + SecondEnter;
			yield return new WaitForSeconds (0.5f);
			gameObject.SetActive(false);
		}
	}
}