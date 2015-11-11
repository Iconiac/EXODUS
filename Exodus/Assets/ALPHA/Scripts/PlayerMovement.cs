using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{

	public float speed;
	

	void Update () 
	{
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis ("Vertical");

		if (h != 0) 
		{
			transform.position += Vector3.right * Time.deltaTime * speed *h;
		}

		if (v != 0)
		{
			transform.position += Vector3.forward * Time.deltaTime * speed *v;
		}

	}
}
