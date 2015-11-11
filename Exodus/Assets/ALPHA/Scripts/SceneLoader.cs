using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Invoke("LoadMain", 3);
	}

	void LoadMain()
	{
		Application.LoadLevel("Exodus_Alpha");
	}
}
