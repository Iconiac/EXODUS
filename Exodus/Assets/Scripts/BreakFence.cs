using UnityEngine;
using System.Collections;

public class BreakFence : MonoBehaviour
{
    [SerializeField] GameObject BrokenFence;
    [SerializeField] GameObject CompleteFence;

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            CompleteFence.SetActive(false);
            BrokenFence.SetActive(true);
            GetComponent<AudioSource>().Play();
            gameObject.SetActive(false);
        }
    }

}
