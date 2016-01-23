﻿using UnityEngine;
using System.Collections;

	public class QuestComplete : MonoBehaviour
	{

		[SerializeField] float killDistance;
        [SerializeField] AudioSource GunShot;
        [SerializeField] AudioSource Fence;
		[SerializeField] GameObject CarExplosion;

		private GameObject _parent;

		public void QuestEvent()
		{
			_parent = GameObject.Find ("Parent");
			gameObject.GetComponent<BoxCollider>().isTrigger = true;
			_parent.GetComponent<Rigidbody>().isKinematic = false;
		}

		void Update()
		{

			if (_parent != null)
			{
			if (Vector3.Distance(_parent.transform.position, transform.position) <= killDistance)
			{
				CarExplosion.SetActive(true);
                GunShot.Play();
				Destroy(_parent);
			}
			}
		}

		void OnTriggerEnter (Collider col)
		{
			if (col.gameObject.CompareTag("Player"))
			{
				if (_parent != null)
				{
                Fence.Play();
				_parent.GetComponent<ParentMove>().target = gameObject.transform.position;
                _parent.GetComponent<Animator>().SetTrigger("Walking");
				}
			}
		}
	}

