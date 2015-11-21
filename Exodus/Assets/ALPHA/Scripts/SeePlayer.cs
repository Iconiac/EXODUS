using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	public class SeePlayer : MonoBehaviour 
	{
		[SerializeField] float FieldOfViewAngle = 110f;           
		[SerializeField] float Speed = 0.07f;
		[SerializeField] string Discovery;
		[SerializeField] GameObject Eyes;
		[SerializeField] float ViewDistance;
		[SerializeField] bool ShouldRotate;
		[SerializeField] Transform[] Waypoints;

		private int _cur = 0;
		private Text _discovery;
		private GameObject _player;
		private GameObject _sister;
		private GameObject _playerHead;
		private GameObject _sisterHead;
		private RaycastHit _hit;
		private bool _playerInSight;
		private ThirdPersonUserControl _move;
		private float _moveSpeed;
		private float _animSpeed;
		private Vector3 _sisterTarget;
		
		void Awake()
		{
			_sister = GameObject.Find ("LilSister");
			_player = GameObject.FindWithTag("Player");
			_sisterHead = GameObject.Find ("SisterHead");
			_playerHead = GameObject.Find ("PlayerHead");
			_discovery = GameObject.Find ("InGameText").GetComponent<Text> ();
			_move = _player.GetComponent<ThirdPersonUserControl>();
			_moveSpeed = _player.GetComponent<ThirdPersonCharacter>().m_MoveSpeedMultiplier;
			_animSpeed = _player.GetComponent<ThirdPersonCharacter>().m_AnimSpeedMultiplier;
			_sisterTarget = _sister.GetComponent<SisterMovement>().target;
		}
	
		void FixedUpdate()
		{
	
			if (_playerInSight == false)
			{
				if (transform.position != Waypoints [_cur].position) 
				{
					Vector3 p = Vector3.MoveTowards (transform.position, Waypoints [_cur].position, Speed);
					GetComponent<Rigidbody> ().MovePosition (p);
				
					if (ShouldRotate == true)
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
					Vector3 direction = _playerHead.transform.position - Eyes.transform.position;
					float angle = Vector3.Angle(direction, Eyes.transform.forward);
	
					if(angle < FieldOfViewAngle * 0.5f)
					{
						if(Physics.Raycast(Eyes.transform.position, direction.normalized, out _hit, ViewDistance))
						{
							if(_hit.collider.gameObject == _player)
							{
								LoseGame();
								_playerInSight = true;
							}
						}
					}
				}
				
			if (other.gameObject == _sister)
			{
				Vector3 direction = _sisterHead.transform.position - Eyes.transform.position;
				float angle = Vector3.Angle(direction, Eyes.transform.forward);
				
				if(angle < FieldOfViewAngle * 0.5f)
				{
					if(Physics.Raycast(Eyes.transform.position, direction.normalized, out _hit, ViewDistance))
					{
						if(_hit.collider.gameObject == _sister)
						{	
							LoseGame();
							_playerInSight = true;
						}
					}
				}
			}
		}
	
	
		void LoseGame()
		{
			_discovery.text = "" + Discovery;
			_move.enabled = false;
			_moveSpeed = 0f;
			_animSpeed = 0f;
			_sisterTarget = _sister.transform.position;
			Invoke ("Restart", 4f);
		}
	
		void Restart()
		{
			Application.LoadLevel("First");
		}
	}
}
