using UnityEngine;
using System.Collections;

	public class SisterMovement : MonoBehaviour 
	{
		public NavMeshAgent agent { get; private set; }

		private void Start()
		{
			agent = GetComponentInChildren<NavMeshAgent>();
			agent.updateRotation = true;
			agent.updatePosition = true;
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
				}

			}
			
		}
	}


