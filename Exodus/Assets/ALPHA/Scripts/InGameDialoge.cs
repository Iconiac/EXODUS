using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InGameDialoge : MonoBehaviour 
{
	[SerializeField] string TextToShow;

	private Text _inGameText;

	void Start()
	{
		_inGameText = GameObject.Find("InGameText").GetComponent<Text>();
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.name == "Player")
		{
			_inGameText.text = "" + TextToShow;
			gameObject.SetActive(false);
		}
	}

}
