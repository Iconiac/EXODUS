using UnityEngine;
using System.Collections;

public class ActivateTeddy : MonoBehaviour 
{
	[SerializeField] GameObject Teddy;

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "Player")
		{
			if (!Decisions.TeddyTaken)
			{
				Teddy.SetActive(true);
			}
		}
	}
}
