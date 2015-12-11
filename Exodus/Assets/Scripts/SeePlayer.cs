using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	public class SeePlayer : MonoBehaviour 
	{
		[SerializeField] float FieldOfViewAngle = 110f;           
		[SerializeField] float Speed = 0.07f;
        [SerializeField] float ViewDistance;
        [SerializeField] string[] Discovery;
		[SerializeField] bool ShouldRotate;
        [SerializeField] Text InGameText;
		[SerializeField] Transform[] Waypoints;
        [SerializeField] GameObject DialogePanel;
		[SerializeField] GameObject Checkpoint;
		[SerializeField] GameObject CameraToActivate;
		[SerializeField] GameObject CameraToDeactivate;

        private bool _playerInSight;
        private int _cur = 0;
        private int _index;
		private RaycastHit _hit;
        private GameObject[] _players;
		
		void Awake()
		{
            _players = GameObject.FindGameObjectsWithTag("Player");
            _index = Random.Range(0, Discovery.Length);
		}

	void Update()
        {
            foreach(GameObject player in _players)
            {
                Vector3 direction = player.transform.position - this.transform.position;
                float angle = Vector3.Angle(direction, this.transform.forward);

                if (angle < FieldOfViewAngle * 0.5f)
                {
                    if (Physics.Raycast(this.transform.position, direction.normalized, out _hit, ViewDistance))
                    {
                        if (_hit.collider.gameObject == player)
                        {
                            LoseGame();
                            _playerInSight = true;
                        }
                    }
                }
            }
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

		void LoseGame()
		{
            DialogePanel.SetActive(true);
            InGameText.text = "" + Discovery[_index];
            foreach (GameObject _player in _players)
            {
                _player.GetComponent<NavMeshAgent>().enabled = false;
            }

			if (gameObject.tag == "Enemy")
			{
				Invoke ("Restart", 4f);
			}

			else if (gameObject.tag == "Spotlight")
			{
				Invoke ("Respawn", 4f);
			}
		}
	
		void Restart()
		{
			Application.LoadLevel("City_Scene");
		}

		/*void Respawn()
		{
			Player.transform.position = Checkpoint.transform.position;
			_playerInSight = false;
			CameraToActivate.SetActive(true);
			CameraToDeactivate.SetActive(false);
			_discovery.text = "Soll ich Ihren Teddy holen oder weitergehen?"; 
		}*/

	}
}
