using UnityEngine;
using System.Collections;

public class ParentMove : MonoBehaviour 
{
	[SerializeField] GameObject goal;

	public NavMeshAgent agent { get; private set; }
	public Vector3 target;

    private Animator _anim;

	private void Start()
	{
        _anim = GetComponent<Animator>();
		agent = GetComponentInChildren<NavMeshAgent>();

		if (gameObject.tag == "Parent")
		{
			target = goal.transform.position;
            _anim.SetTrigger("Walking");
		}

		else
		{
			target = this.transform.position;
		}

		agent.updateRotation = false;
		agent.updatePosition = true;
	}
	
	private void Update()
	{
		agent.SetDestination(target);	
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject == goal)
		{
			Destroy(gameObject);
		}
	}
}


