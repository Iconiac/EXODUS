using UnityEngine;
using System.Collections;


public class DecisionCity : MonoBehaviour 
{

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.name == "Screen1Border_Children")
		{
			if (col.gameObject.tag == "MomWay")
			{
                Decisions.MomChosen = true;
                Decisions.DadChosen = false;
			}
			
			if (col.gameObject.tag == "DadWay")
			{
                Decisions.MomChosen = false;
                Decisions.DadChosen = true;
			}	
		}
	}
}

