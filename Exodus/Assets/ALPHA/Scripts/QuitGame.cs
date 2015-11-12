using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour 
{
	void CloseGame()
	{
		if (Input.GetKey (KeyCode.Escape))
		{
			Application.Quit ();
		}
	}
}
