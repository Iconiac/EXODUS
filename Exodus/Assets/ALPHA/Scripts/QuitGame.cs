using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour 
{
	void Update()
	{
		if (Input.GetKey (KeyCode.Escape))
		{
			Application.Quit ();
		}
	}
}
