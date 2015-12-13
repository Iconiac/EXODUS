using UnityEngine;
using System.Collections;

public class LoadCredits : MonoBehaviour
{
    [SerializeField] GameObject CreditScreen;

    private GameObject _cutscene;
	
	void Start ()
    {
        _cutscene = GameObject.FindWithTag("Cutscene");
        Invoke("Credits", 15f);
	}

    void Credits()
    {
        _cutscene.SetActive(false);
        CreditScreen.SetActive(true);
    }
}
