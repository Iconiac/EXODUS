using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Interaction : MonoBehaviour
{
    [SerializeField] GameObject DialogePanel;
    [SerializeField] Text Dialoge;
    [SerializeField] float Interval;
    [SerializeField] string TextToShow;

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Interact"))
            {
                DialogePanel.SetActive(true);
                StartCoroutine("Questing");
                Invoke("DisablePanel", Interval);
            }
        }
    }

    IEnumerator Questing()
    {
        GetComponent<DialogueController>().ShowDialogue();
        yield return new WaitForSeconds(0.5f);
        GetComponent<QuestController>().QuestEvent();
    }

    void DisablePanel()
    {
        DialogePanel.SetActive(false);
    }
}
