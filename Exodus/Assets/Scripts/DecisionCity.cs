using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
public class DecisionCity : MonoBehaviour 
{

	[SerializeField] GameObject Mom;
	[SerializeField] GameObject Dad;

	private bool _dadChosen;
	private bool _momChosen;

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "Screen1Border")
		{
			if (col.gameObject.tag == "MomWay")
			{
				_momChosen = true;
			}
			
			if (col.gameObject.tag == "DadWay")
			{
				_dadChosen = true;
			}	
		}
		
		if (col.gameObject.name == "Screen2Border")
		{
			if (_momChosen == true)
			{
				Mom.SetActive(true);
				//Mom.GetComponent<QuestController>().questTarget.SetActive(true);
			}
			
			if (_dadChosen == true)
			{
				Dad.SetActive(true);
				//Dad.GetComponent<QuestController>().questTarget.SetActive(true);
			}

		}
		
	}
}
}
