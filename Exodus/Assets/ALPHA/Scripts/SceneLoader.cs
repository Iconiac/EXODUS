using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour 
{

	[SerializeField] string sceneToLoad;
	[SerializeField] GameObject player;

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject == player)
		{
			Application.LoadLevel(sceneToLoad);
		}
	}
}
