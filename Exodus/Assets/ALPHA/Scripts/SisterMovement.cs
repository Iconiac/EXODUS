using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	[RequireComponent(typeof (NavMeshAgent))]
	[RequireComponent(typeof (ThirdPersonCharacter))]
	public class SisterMovement : MonoBehaviour 
	{
		[SerializeField] GameObject GoTerrain;
		[SerializeField] GameObject Port;

		public NavMeshAgent agent { get; private set; }
		public ThirdPersonCharacter character { get; private set; }
		public Vector3 target;

		private Collider _portCollider;
		private Collider _terrainCollider;

		private void Start()
		{
			agent = GetComponentInChildren<NavMeshAgent>();
			character = GetComponent<ThirdPersonCharacter>();
			target = this.transform.position;
			agent.updateRotation = false;
			agent.updatePosition = true;
			_portCollider = Port.GetComponent<Collider>();
			_terrainCollider = GoTerrain.GetComponent<Collider>();
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
				
				if (_terrainCollider.Raycast(ray, out hit, Mathf.Infinity))
				{
					target = hit.point;
				}
				
				if (_portCollider.Raycast(ray, out hit, Mathf.Infinity))
				{
					target = hit.point;
				}
			}
			
		}
	}
}

