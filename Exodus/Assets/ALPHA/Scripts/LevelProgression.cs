using UnityEngine;
using System.Collections;

public class LevelProgression : MonoBehaviour 
{
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag ("Player"))
		{
			Application.LoadLevel("Exodus_Scene2");
		}
	}
}
