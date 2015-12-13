using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour 
{

	[SerializeField] string SceneToLoad;

    void Start()
    {
        Cursor.visible = false;
        Invoke("LoadMenu", 3f);
    }
	void LoadMenu()
	{
		Application.LoadLevel(SceneToLoad);
	}
}
