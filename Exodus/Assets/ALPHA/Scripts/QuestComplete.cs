using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	public class QuestComplete : MonoBehaviour
	{
		[SerializeField] GameObject parent;
		[Range(0.0f, 5.0f)]public float killDistance;

		private ParentMove _parent;

		void Start()
		{
			_parent = parent.GetComponent<ParentMove>();
		}

		public void QuestEvent()
		{
			gameObject.GetComponent<BoxCollider>().isTrigger = true;
			parent.GetComponent<Rigidbody>().isKinematic = false;
		}

		void Update()
		{
			if (parent != null)
			{
			if (Vector3.Distance(parent.transform.position, transform.position) <= killDistance)
			{
				Destroy(parent);
			}
			}
		}

		void OnTriggerEnter (Collider col)
		{
			if (col.gameObject.CompareTag("Player"))
			{
				if (parent != null)
				{
					_parent.target = gameObject.transform.position;
				}
			}
		}
	}
}
