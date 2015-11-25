using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
public class Interact : MonoBehaviour 
{
	[SerializeField] float InteractDistance;

	private float _currentshortestDistance;
	private GameObject _intTarget;
	//private DialogueController _dialoge;

	
	/*void Awake()
	{
		_dialoge = _intTarget.GetComponent<DialogueController>(); //Unmöglich in diesem Fall da _intTarget zu Beginn null ist
																  //NullReferenceException beim Start :[
	}*/

	void FixedUpdate()
	{
		_intTarget = null;
		_currentshortestDistance = InteractDistance;
		
		GameObject[] PotentialTargets = GameObject.FindGameObjectsWithTag("NPC");
		
		for (int i = 0; i < PotentialTargets.Length; i++) 
		{
			
			float distance = Vector3.Distance (gameObject.transform.position, PotentialTargets [i].transform.position);
			if (distance <= _currentshortestDistance) 
			{
				_currentshortestDistance = distance;
				_intTarget = PotentialTargets[i];
			}
		}

		if (_intTarget != null)
		{
			if (Input.GetButtonDown ("Interact"))
			{
				if (_intTarget.GetComponent<DialogueController>().DuringQuest != "")
				{
					StartCoroutine("Questing");
				}

				else
				{
					_intTarget.GetComponent<DialogueController>().Story();
				}
			}
		}
	}

	IEnumerator Questing()
	{
		_intTarget.GetComponent<DialogueController>().ShowDialogue();
		yield return new WaitForSeconds (0.5f);
		_intTarget.GetComponent<QuestController>().QuestEvent();
	}
}
}
