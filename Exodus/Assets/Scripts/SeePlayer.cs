using UnityEngine;
using System.Collections;
using UnityEngine.UI;

	public class SeePlayer : MonoBehaviour 
	{
		[SerializeField] float FieldOfViewAngle = 110f;           
		[SerializeField] float Speed = 0.07f;
        [SerializeField] float ViewDistance;
        [SerializeField] string[] Discovery;
        [SerializeField] string RespawnText;
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
            StartCoroutine("Restart");
        }

        else if (gameObject.tag == "Spotlight")
			{
				StartCoroutine ("Respawn");
			}
		}

   IEnumerator Restart()
    {
        yield return new WaitForSeconds(3f);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1f);
        Application.LoadLevel("City_Scene");
    }

    IEnumerator Respawn()
		{
		yield return new WaitForSeconds (4f);
			//PlayerInSight = false;
			CameraToActivate.SetActive(true);
			CameraToDeactivate.SetActive(false);
			InGameText.text = "" + RespawnText;
		foreach (GameObject _player in _players)
		{
			_player.GetComponent<NavMeshAgent>().enabled = true;
		}
		Player.GetComponent<NavMeshAgent>().Warp(Checkpoint.transform.position);
		yield return new WaitForSeconds (2f);
		DialogePanel.SetActive(false);

            gameObject.transform.position = _startPosition;
		PlayerInSight = false;
            gameObject.SetActive(false);
        }

	}

