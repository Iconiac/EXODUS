using UnityEngine;
using System.Collections;

public class DialogeTrigger : MonoBehaviour {

    [SerializeField] GameObject DialogePanel;
        

    private GameObject _player;
    private GameObject _sister;
 
    void Start()
    {
        _player = GameObject.Find("Player");
        _sister = GameObject.Find("LilSister");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == _player)
        {
            StartCoroutine("DisableMovement");
        }
    }

    IEnumerator DisableMovement()
    {
        DialogePanel.SetActive(true);
        _player.GetComponent<NavMeshAgent>().enabled = false;
        _sister.GetComponent<NavMeshAgent>().destination = _sister.transform.position;
        _sister.GetComponent<SisterMovement>().Walking = false;
        yield return new WaitForSeconds(0.5f);
        _sister.GetComponent<SisterMovement>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);

    }
}
