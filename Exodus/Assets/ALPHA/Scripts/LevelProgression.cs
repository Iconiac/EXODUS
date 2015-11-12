using UnityEngine;
using System.Collections;

public class LevelProgression : MonoBehaviour 
{
	[SerializeField] string game;


	void Update()
	{
		if (Input.GetButton ("Interact"))
		{
			Application.LoadLevel (game);
		}
	}

	/*void ChangeScene()
	{
		if (Input.GetButton ("Interact"))
		{
			Application.LoadLevel ("First");
		}
	}*/
	            
}
