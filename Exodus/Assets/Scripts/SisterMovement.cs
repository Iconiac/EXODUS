using UnityEngine;
using System.Collections;

public class SisterMovement : MonoBehaviour 
{
	public NavMeshAgent agent { get; private set; }

    private Animator _anim;
    private bool _walking;
      

//       Animator anim;

	private void Start()
	{
		agent = GetComponentInChildren<NavMeshAgent>();
		agent.updateRotation = true;
		agent.updatePosition = true;
        _anim = GetComponent<Animator>();
	}

	private void Update()
	{
		if (Input.GetMouseButton (0)) 
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			
			if (Physics.Raycast(ray, out hit, Mathf.Infinity))
			{
				agent.destination = hit.point;
                Debug.Log(agent.destination);    
			}

            //               anim.SetBool("IsWalking", true);
        }
        if (agent.remainingDistance >= agent.stoppingDistance)
        {
            _walking = true;
        }

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            _walking = false;
        }
        _anim.SetBool("IsWalking", _walking);

    }
}


