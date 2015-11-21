using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour 
{

	[SerializeField] string SceneToLoad;
	[SerializeField] GameObject Player;

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject == Player)
		{
			Invoke ("LoadEnd", 8f);
		}
	}

	void LoadEnd()
	{
		Application.LoadLevel(SceneToLoad);
	}
}
