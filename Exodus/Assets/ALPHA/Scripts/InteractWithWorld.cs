using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
public class InteractWithWorld : MonoBehaviour 

{

	[SerializeField] float InteractDistance;

	private float _currentshortestDistance;
	private GameObject _intTarget;

	void FixedUpdate()
	{
		_intTarget = null;
		_currentshortestDistance = InteractDistance;

			Debug.Log (_intTarget);
		
		GameObject[] PotentialTargets = GameObject.FindGameObjectsWithTag("Target");
		
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
				StartCoroutine("Questing");
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
