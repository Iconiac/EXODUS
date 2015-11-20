using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
public class DecisionCity : MonoBehaviour 
{

	[SerializeField] GameObject Mom;
	[SerializeField] GameObject Dad;

	private bool dadChosen;
	private bool momChosen;

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "Screen1Border")
		{
			if (col.gameObject.tag == "MomWay")
			{
				momChosen = true;
			}
			
			if (col.gameObject.tag == "DadWay")
			{
				dadChosen = true;
			}	
		}
		
		if (col.gameObject.name == "Screen2Border")
		{
			if (momChosen == true)
			{
				Mom.SetActive(true);
				Mom.GetComponent<QuestController>().questTarget.SetActive(true);
			}
			
			if (dadChosen == true)
			{
				Dad.SetActive(true);
				Dad.GetComponent<QuestController>().questTarget.SetActive(true);
			}

		}
		
	}
}
}
