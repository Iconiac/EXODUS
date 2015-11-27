using UnityEngine;
using System.Collections;

public class Start_ExitGame : MonoBehaviour 
{


	void Start () 
	{
	
	}
	

	void Update () 
	{
	
	}

	public void StartGame () 
	{
		Application.LoadLevel ("First");
	}

	public void ExitGame () 
	{
		Application.Quit ();
	}
}
