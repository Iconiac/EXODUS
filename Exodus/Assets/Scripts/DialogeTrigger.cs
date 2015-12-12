using UnityEngine;
using System.Collections;

public class DialogeTrigger : MonoBehaviour {

    [SerializeField] GameObject DialogePanel;
        

    private GameObject[] _players;
 
    void Start()
    {
        _players = GameObject.FindGameObjectsWithTag("Player");
    }

    void OnTriggerEnter(Collider col)
    {
        foreach (GameObject _player in _players)
        {
            if (col.gameObject == _player)
            {
                DisableMovement();
                DialogePanel.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }

    void DisableMovement()
    {
        foreach( GameObject _player in _players)
        {
            _player.GetComponent<NavMeshAgent>().enabled = false;
        }
    }
}
