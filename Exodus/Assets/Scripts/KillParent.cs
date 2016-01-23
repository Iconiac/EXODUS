using UnityEngine;
using System.Collections;

public class KillParent : MonoBehaviour 
{

	[SerializeField] GameObject Explosion;

void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.name == "Parent")
		{
			Explosion.SetActive(true);
			Destroy(col.gameObject);
			Invoke ("LoadMountain", 7f);
		}
	}

	void LoadMountain()
	{
		Application.LoadLevel("Mountain_Scene");
	}
}
