using UnityEngine;
using System.Collections;

public class SeePlayer : MonoBehaviour 
{
	public float fieldOfViewAngle = 110f;           
	public bool playerInSight;
	private bool sisterInSight;
	public GameObject sister;
	public GameObject sisterHead;
	private GameObject player;                      
	private RaycastHit hit;
	public GameObject eyes;
	public float viewDistance;
	public GameObject playerHead;
	private Quaternion startRot;
	public bool rot;
	public Transform[] waypoints;
	private int cur = 0;
	public float speed = 0.3f;
	
	void Awake()
	{
		player = GameObject.FindWithTag("Player");
		startRot = transform.rotation;
	}

	void FixedUpdate()
	{
		if (playerInSight == false && sisterInSight == false)
		{
		if (transform.position != waypoints [cur].position) 
		{
			Vector3 p = Vector3.MoveTowards (transform.position, waypoints [cur].position, speed);
			GetComponent<Rigidbody> ().MovePosition (p);
			if (rot == true)
			{
				transform.LookAt (p);
			}
		} 
		if (transform.position == waypoints[cur].position)
			{
			cur = (cur + 1) % waypoints.Length;
			}
		}
	}

		void OnTriggerStay (Collider other)
		{

			if(other.gameObject == player)
			{
				Debug.Log("Is in Collider");
				Vector3 direction = playerHead.transform.position - eyes.transform.position;
				float angle = Vector3.Angle(direction, eyes.transform.forward);

				if(angle < fieldOfViewAngle * 0.5f)
				{
				Debug.DrawLine(eyes.transform.position, hit.point);
					if(Physics.Raycast(eyes.transform.position, direction.normalized, out hit, viewDistance))
					{
						if(hit.collider.gameObject == player)
						{
							playerInSight = true;

						if(sisterInSight == false)
						{
							transform.LookAt(playerHead.transform.position);
						}
						}
					}
				}
			}
			
		if (other.gameObject == sister)
		{
			Vector3 direction = sisterHead.transform.position - eyes.transform.position;
			float angle = Vector3.Angle(direction, eyes.transform.forward);
			
			if(angle < fieldOfViewAngle * 0.5f)
			{
				Debug.DrawLine(eyes.transform.position, hit.point);
				if(Physics.Raycast(eyes.transform.position, direction.normalized, out hit, viewDistance))
				{
					if(hit.collider.gameObject == sister)
					{
						sisterInSight = true;
						if (playerInSight == false)
						{
						transform.LookAt(sisterHead.transform.position);
						}
					}
				}
			}
		}
	}

		void OnTriggerExit (Collider other)
		{
			if(other.gameObject == player)
			{
				playerInSight = false;
				transform.rotation = startRot;
			}

			if(other.gameObject == sister)
			{
				sisterInSight = false;
				transform.rotation = startRot;
			}
		}
}
