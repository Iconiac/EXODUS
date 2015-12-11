using UnityEngine;
using System.Collections;

public class InGameSceneChange : MonoBehaviour
{
    [SerializeField] string SceneToLoad;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Application.LoadLevel(SceneToLoad);
        }
    }

}
