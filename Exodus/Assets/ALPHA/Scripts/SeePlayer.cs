using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.ThirdPerson
{
public class SeePlayer : MonoBehaviour 
{
	public float fieldOfViewAngle = 110f;           
	public bool playerInSight;
	public GameObject sister;
	public GameObject sisterHead;
	private GameObject player;                      
	private RaycastHit hit;
	public GameObject eyes;
	public float viewDistance;
	public GameObject playerHead;
	public bool rot;
	public Transform[] waypoints;
	private int cur = 0;
	public float speed = 0.3f;
	public string Discovery;
	private Text _discovery;
	
	void Awake()
	{
		player = GameObject.FindWithTag("Player");
		_discovery = GameObject.Find ("InGameText").GetComponent<Text> ();
	}

	void FixedUpdate()
	{

		if (playerInSight == false)
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
				Vector3 direction = playerHead.transform.position - eyes.transform.position;
				float angle = Vector3.Angle(direction, eyes.transform.forward);

				if(angle < fieldOfViewAngle * 0.5f)
				{
					if(Physics.Raycast(eyes.transform.position, direction.normalized, out hit, viewDistance))
					{
						if(hit.collider.gameObject == player)
						{
							LoseGame();
							playerInSight = true;
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
				if(Physics.Raycast(eyes.transform.position, direction.normalized, out hit, viewDistance))
				{
					if(hit.collider.gameObject == sister)
					{	
						LoseGame();
						playerInSight = true;
					}
				}
			}
		}
	}


	void LoseGame()
	{
		_discovery.text = "" + Discovery;
		player.GetComponent<ThirdPersonUserControl>().enabled = false;
			player.GetComponent<ThirdPersonCharacter>().m_MoveSpeedMultiplier = 0f;
			player.GetComponent<ThirdPersonCharacter>().m_AnimSpeedMultiplier = 0f;
		sister.GetComponent<SisterMovement>().target = sister.transform.position;
		Invoke ("Restart", 4f);
	}

	void Restart()
	{
		Application.LoadLevel("First");
	}
}
}
