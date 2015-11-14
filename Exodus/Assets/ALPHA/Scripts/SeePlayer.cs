using UnityEngine;
using System.Collections;

public class SeePlayer : MonoBehaviour 
{
	[SerializeField] float FieldOfViewAngle = 110f;           
	[SerializeField] bool PlayerInSight;
	[SerializeField] GameObject Sister;
	[SerializeField] GameObject SisterHead;
	[SerializeField] float Speed = 0.3f;
	[SerializeField] GameObject Eyes;
	[SerializeField] float ViewDistance;
	[SerializeField] GameObject PlayerHead;
	[SerializeField] bool Rotate;
	[SerializeField] Transform[] Waypoints;

	private bool _sisterInSight;
	private GameObject _player;                      
	private RaycastHit _hit;
	private Quaternion _startRot;
	private int _cur = 0;
	private Rigidbody _rigidbody;

	
	void Awake()
	{
		_player = GameObject.FindWithTag("Player");
		_startRot = transform.rotation;
		_rigidbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		if (PlayerInSight == false && _sisterInSight == false)
		{
		if (transform.position != Waypoints [_cur].position) 
		{
			Vector3 p = Vector3.MoveTowards (transform.position, Waypoints [_cur].position, Speed);
			_rigidbody.MovePosition (p);

			if (Rotate == true)
			{
				transform.LookAt (p);
			}
		}

		if (transform.position == Waypoints[_cur].position)
			{
			_cur = (_cur + 1) % Waypoints.Length;
			}
		}
	}

	void OnTriggerStay (Collider other)
	{

		if(other.gameObject == _player)
		{
			Vector3 direction = PlayerHead.transform.position - Eyes.transform.position;
			float angle = Vector3.Angle(direction, Eyes.transform.forward);

			if(angle < FieldOfViewAngle * 0.5f)
			{

				if(Physics.Raycast(Eyes.transform.position, direction.normalized, out _hit, ViewDistance))
				{

					if(_hit.collider.gameObject == _player)
					{
						PlayerInSight = true;

						if(_sisterInSight == false)
						{
							transform.LookAt(PlayerHead.transform.position);
						}
					}
				}
			}
		}
			
		if (other.gameObject == Sister)
		{
			Vector3 direction = SisterHead.transform.position - Eyes.transform.position;
			float angle = Vector3.Angle(direction, Eyes.transform.forward);
			
			if(angle < FieldOfViewAngle * 0.5f)
			{

				if(Physics.Raycast(Eyes.transform.position, direction.normalized, out _hit, ViewDistance))
				{

					if(_hit.collider.gameObject == Sister)
					{
						_sisterInSight = true;

						if (PlayerInSight == false)
						{
							transform.LookAt(SisterHead.transform.position);
						}
					}
				}
			}
		}
	}

		void OnTriggerExit (Collider other)
		{
			if(other.gameObject == _player)
			{
				PlayerInSight = false;
				transform.rotation = _startRot;
			}

			if(other.gameObject == Sister)
			{
				_sisterInSight = false;
				transform.rotation = _startRot;
			}
		}
}
