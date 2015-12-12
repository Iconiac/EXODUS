using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Dialoges : MonoBehaviour 
{
	public List<string> Keys;
	public List<string> Values;

	void Awake()
	{
		DialogeBase.GetDialoge(Keys, Values);
	}

}

