using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{

	[SerializeField] float Speed;

    private NavMeshAgent _agent;
	private GameObject _cam;

    void Start()
    {
		_agent = GetComponent<NavMeshAgent>();
    }	

	void FixedUpdate () 
	{
		_cam = GameObject.Find("Camera");

		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		if (h != 0) 
		{
			transform.position += _cam.transform.right * Time.deltaTime * Speed *h;
            transform.forward = _cam.transform.TransformDirection(new Vector3(h, 0f, v));
        }

		if (v != 0)
		{
			transform.position += _cam.transform.forward * Time.deltaTime * Speed *v;
			transform.forward = _cam.transform.TransformDirection(new Vector3(h, 0f, v));
        }
	}
}
