using UnityEngine;
using System.Collections;
using UnityEngine.UI;

    public class ScreenChange : MonoBehaviour
    {

        [SerializeField] GameObject PositionToSpawnAt;
        [SerializeField] GameObject DialogePanel;
        [SerializeField] GameObject CameraToActivate;
        [SerializeField] GameObject CameraToDeactivate;
		[SerializeField] GameObject[] EnemiesToActivate;
		[SerializeField] GameObject[] OptionalThingsToActivate;
		[SerializeField] GameObject[] OptionalThingsToDeactivate;
        [SerializeField] Text InGameText;
		[SerializeField] string TextToShow;
		[SerializeField] string TextForTooMuchDistance;
		[SerializeField] float ChangeDistance;
		[SerializeField] bool ShouldSisterStay;

		private GameObject _sister;
		private GameObject _player;
		private NavMeshAgent _sisterAgent;
        private NavMeshAgent _playerAgent;
        private Vector3 _playerPosition;
        private Vector3 _sisterPosition;
        private Movement _playerMovement;

		void Awake()
		{
			_player = GameObject.Find("Player");
			_sister = GameObject.Find ("LilSister");
			_sisterAgent = _sister.GetComponent<NavMeshAgent>();
            _playerAgent = _player.GetComponent<NavMeshAgent>();
            _sisterPosition = new Vector3(PositionToSpawnAt.transform.position.x, PositionToSpawnAt.transform.position.y, PositionToSpawnAt.transform.position.z - 2);
            _playerPosition = new Vector3(PositionToSpawnAt.transform.position.x, PositionToSpawnAt.transform.position.y, PositionToSpawnAt.transform.position.z);
            _playerMovement = _player.GetComponent<Movement>();

        }
			
		void OnTriggerEnter (Collider col)
		{
			if (col.gameObject.tag == "Player")
			{
				if (Vector3.Distance(_sister.transform.position, _player.transform.position) <= ChangeDistance)
				{
					CameraToActivate.SetActive(true);
                    CameraToDeactivate.SetActive(false);
                    //Set next cam for movement directions
                    _playerMovement.SetCam(CameraToActivate);
                    _playerAgent.Warp(_playerPosition);

					if (ShouldSisterStay == false)
					{
						_sisterAgent.Warp(_sisterPosition);
					}
                    if (TextToShow != "")
                    {
                        DialogePanel.SetActive(true);
                        InGameText.text = "" + TextToShow;
                        Invoke("DisablePanel", 4f);
                    }
					
					foreach (GameObject enemy in EnemiesToActivate)
					{
						enemy.SetActive (true);
					}
					
					foreach (GameObject stuff in OptionalThingsToActivate)
					{
						stuff.SetActive(true);
					}
					
					foreach (GameObject stuff in OptionalThingsToDeactivate)
					{
						stuff.SetActive(false);
					}
					
				}

				else if (Vector3.Distance(_sister.transform.position, _player.transform.position) >= ChangeDistance)
				{
                    DialogePanel.SetActive(true);
                    InGameText.text = "" + TextForTooMuchDistance;
                    Invoke("DisablePanel", 4f);
                }

			}
		}

        void DisablePanel()
        {
            DialogePanel.SetActive(false);
        }

	}

