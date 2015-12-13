using UnityEngine;
using System.Collections;


public class DecisionCity : MonoBehaviour 
{

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "Screen1Border")
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

