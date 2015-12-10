using UnityEngine;
using System.Collections;

public class EnemyLight : MonoBehaviour
{
    [SerializeField] string SceneToLoad;

    private GameObject _player;
    private GameObject _sister;

    void Start()
    {
        _player = GameObject.Find("Player");
        _sister = GameObject.Find("LilSister");

    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject == _player || col.gameObject == _sister)
        {
            Invoke("LoseGame", 7f);
        }
    }

    void LoseGame()
    {
        Application.LoadLevel(SceneToLoad);
    }

}
