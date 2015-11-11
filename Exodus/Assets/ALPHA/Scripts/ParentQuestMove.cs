﻿using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	[RequireComponent(typeof (NavMeshAgent))]
	[RequireComponent(typeof (ThirdPersonCharacter))]
	public class ParentQuestMove : MonoBehaviour 
	{
		public NavMeshAgent agent { get; private set; }
		public ThirdPersonCharacter character { get; private set; }
		public Vector3 target;
		
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
			
		}

	}
}