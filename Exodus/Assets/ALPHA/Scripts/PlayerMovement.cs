using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{

	[SerializeField] float Speed;

    private NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }	

	void Update () 
	{
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		if (h != 0) 
		{
			_agent.Move(Vector3.right * Time.deltaTime * Speed *h);
            transform.forward = Vector3.Normalize(new Vector3(h, 0f, v));
        }

		if (v != 0)
		{
			_agent.Move (Vector3.forward * Time.deltaTime * Speed *v);
            transform.forward = Vector3.Normalize(new Vector3(h, 0f, v));
        }

	}
}
