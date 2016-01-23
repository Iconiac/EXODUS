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
		}
	}
}
