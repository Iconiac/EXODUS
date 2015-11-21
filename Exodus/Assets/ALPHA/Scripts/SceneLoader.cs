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
			Application.LoadLevel(SceneToLoad);
		}
	}
}
