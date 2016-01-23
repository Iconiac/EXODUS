using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Interaction : MonoBehaviour
{
    [SerializeField] GameObject DialogePanel;
    [SerializeField] GameObject Teddy;
    [SerializeField] GameObject GarageLight;
    [SerializeField] GameObject FenceLight;
    [SerializeField] GameObject FenceTrigger;
    [SerializeField] float Interval;
	[SerializeField] string TextToShow;
	[SerializeField] Text InGameText;

    private GameObject _player;
    private GameObject _sister;
	private SphereCollider _collider;

    void Start()
    {
        _player = GameObject.Find("Player");
        _sister = GameObject.Find("LilSister");
		_collider = GetComponent<SphereCollider>();
    }

    void OnTriggerEnter (Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
			if (gameObject.tag == "QuestParent")
			{
                if (!GetComponent<QuestController>().QuestCompleted)
                {
                    GarageLight.SetActive(true);
                }

                if(GetComponent<QuestController>().QuestCompleted)
                {
                    GarageLight.SetActive(false);
                    FenceLight.SetActive(true);
                    FenceTrigger.SetActive(true);
					_collider.enabled = false;
                }

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
                if (gameObject.CompareTag("Teddy"))
                {
					DialogePanel.SetActive(true);
					Decisions.TeddyTaken = true;
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
