using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
        [SerializeField] GameObject Player;

        public bool PlayerInSight;

        private Vector3 _startPosition;
        private int _cur = 0;
        private int _index;
		private RaycastHit _hit;
        private GameObject[] _players;
		
		void Awake()
		{
            _players = GameObject.FindGameObjectsWithTag("Player");
            _index = Random.Range(0, Discovery.Length);
            _startPosition = gameObject.transform.position;
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
                            PlayerInSight = true;
                        }
                    }
                }
            }
        }

		void FixedUpdate()
		{
	
			if (PlayerInSight == false)
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

		void Respawn()
		{
			PlayerInSight = false;
			CameraToActivate.SetActive(true);
			CameraToDeactivate.SetActive(false);
			InGameText.text = "Soll ich Ihren Teddy holen oder weitergehen?";
            foreach (GameObject _player in _players)
            {
                _player.GetComponent<NavMeshAgent>().enabled = true;
            }
            Player.GetComponent<NavMeshAgent>().Warp(Checkpoint.transform.position);
            gameObject.transform.position = _startPosition;
            gameObject.SetActive(false);
        }

	}

