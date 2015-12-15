using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Interaction : MonoBehaviour
{
    [SerializeField] GameObject DialogePanel;
    [SerializeField] GameObject Teddy;
    [SerializeField] float Interval;
	[SerializeField] string TextToShow;
	[SerializeField] Text InGameText;

    private GameObject _player;
    private GameObject _sister;

    void Start()
    {
        _player = GameObject.Find("Player");
        _sister = GameObject.Find("LilSister");
    }

    void OnTriggerEnter (Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
			if (gameObject.tag == "QuestParent")
			{
				StartCoroutine("Questing");
				Invoke("DisablePanel", Interval);
				DialogePanel.SetActive(true);
			}

		}
	}
	void OnTriggerStay (Collider col)
	{
		if (col.gameObject.CompareTag("Player"))
		{
            if (Input.GetButtonDown("Interact"))
            {
                if (gameObject.CompareTag("Teddy"))
                {
					DialogePanel.SetActive(true);
					InGameText.text = "" + TextToShow;
					Invoke ("DisablePanel", 4f);
					gameObject.SetActive(false);

                }
                DialogePanel.SetActive(true);

                if (gameObject.tag == "Owner")
                {
                    StartCoroutine("PauseGame");
					DialogePanel.SetActive (true);
                }              
            }
        }
    }

    IEnumerator Questing()
    {
        GetComponent<DialogueController>().ShowDialogue();
        yield return new WaitForSeconds(0.5f);
        GetComponent<QuestController>().QuestEvent();
    }

    IEnumerator PauseGame()
    {
        _player.GetComponent<NavMeshAgent>().enabled = false;
        _sister.GetComponent<NavMeshAgent>().destination = _sister.transform.position;
        _sister.GetComponent<SisterMovement>().Walking = false;
        yield return new WaitForSeconds(0.5f);
        _sister.GetComponent<SisterMovement>().enabled = false;
    }

    void DisablePanel()
    {
        DialogePanel.SetActive(false);
    }
}
