using UnityEngine;
using System.Collections;

public class CutsceneSceneChange : MonoBehaviour
{
    [SerializeField] float Interval;
    [SerializeField] string SceneToLoad;

	void Start ()
    {
        Cursor.visible = false;
        Invoke("LoadScene", Interval);
	}

    void LoadScene()
    {
        Application.LoadLevel(SceneToLoad);
    }
	
}
