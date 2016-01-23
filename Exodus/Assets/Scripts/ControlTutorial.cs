using UnityEngine;
using System.Collections;

public class ControlTutorial : MonoBehaviour 
{
	[SerializeField] float FadeInTime;
	[SerializeField] float FadeOutTime; 
	[SerializeField] GameObject Controls;

	void Start () 
	{
		StartCoroutine("ShowControls");
	}

	IEnumerator ShowControls()
	{
		yield return new WaitForSeconds (FadeInTime);
		Controls.SetActive(true);
		yield return new WaitForSeconds (FadeOutTime);
		Controls.SetActive(false);
	}

}
