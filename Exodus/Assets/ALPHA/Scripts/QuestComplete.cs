using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	public class QuestComplete : MonoBehaviour
	{
		public GameObject parent;
		[Range(0.0f, 5.0f)]public float killDistance;

		public void QuestEvent()
		{
			parent = GameObject.Find ("Parent");
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
				parent.GetComponent<ParentQuestMove>().target = gameObject.transform.position;
				}
			}
		}
	}
}
