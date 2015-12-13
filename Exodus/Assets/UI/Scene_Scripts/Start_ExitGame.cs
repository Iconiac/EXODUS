using UnityEngine;
using System.Collections;

public class Start_ExitGame : MonoBehaviour 
{
    [SerializeField] string SceneToLoad;

    void Start()
    {
        Cursor.visible = true;
    }

	public void StartGame () 
	{
		Application.LoadLevel (SceneToLoad);
	}

	public void ExitGame () 
	{
		Application.Quit ();
	}
}
