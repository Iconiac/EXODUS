using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
[RequireComponent(typeof (NavMeshAgent))]
[RequireComponent(typeof (ThirdPersonCharacter))]
public class SisterMovement : MonoBehaviour 
{
	public NavMeshAgent agent { get; private set; }
	public ThirdPersonCharacter character { get; private set; }
	public Vector3 target;
	public GameObject goTerrain;

	private void Start()
	{
		agent = GetComponentInChildren<NavMeshAgent>();
		character = GetComponent<ThirdPersonCharacter>();
		target = this.transform.position;
		agent.updateRotation = false;
		agent.updatePosition = true;
	}

	private void Update()
	{
			agent.SetDestination(target);
			character.Move(agent.desiredVelocity, false, false);

		if (target == transform.position)
		{
			character.Move(Vector3.zero, false, false);
		}
		
		if (Input.GetMouseButton (0)) 
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			
			if (goTerrain.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
			{
				target = hit.point;
			}
		}
		
	}
}
}

