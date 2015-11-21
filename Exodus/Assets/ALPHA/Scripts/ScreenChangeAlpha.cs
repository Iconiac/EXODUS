using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	public class ScreenChangeAlpha : MonoBehaviour 
	{

		[SerializeField] GameObject PositionToSpawnAt;
		[SerializeField] GameObject CameraToActivate;
		[SerializeField] GameObject[] EnemiesToActivate;
		[SerializeField] GameObject[] OptionalThingsToActivate;
		[SerializeField] GameObject[] OptionalThingsToDeactivate;
		[SerializeField] string TextToShow;
		[SerializeField] string TextForTooMuchDistance;
		[SerializeField] float ChangeDistance;
		[SerializeField] bool ShouldSisterStay;

		private GameObject _sister;
		private GameObject _player;
		private GameObject _cameraToDeactivate;
		private SisterMovement _sisterTarget;
		private Text _inGameMessage;

		void Awake()
		{
			_player = GameObject.Find("Player");
			_sister = GameObject.Find ("LilSister");
			_inGameMessage = GameObject.Find ("InGameText").GetComponent<Text> ();
			_sisterTarget = _sister.GetComponent<SisterMovement>();
			_cameraToDeactivate = transform.parent.gameObject;

		}
			
		void OnCollisionEnter (Collision col)
		{
			if (col.gameObject.tag == "Player")
			{
				if (Vector3.Distance(_sister.transform.position, _player.transform.position) <= ChangeDistance)
				{
					Vector3 _sisterPosition = new Vector3 (PositionToSpawnAt.transform.position.x, PositionToSpawnAt.transform.position.y, PositionToSpawnAt.transform.position.z - 2);
					CameraToActivate.SetActive(true);
					_player.transform.position = PositionToSpawnAt.transform.position;

					if (ShouldSisterStay == false)
					{
						_sister.GetComponent<NavMeshAgent>().Warp(_sisterPosition);
						_sisterTarget.target = _sister.transform.position;
					}
					if (TextToShow != "")
					{
						_inGameMessage.text = "" + TextToShow;
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
					
					_cameraToDeactivate.SetActive(false);
				}

				else if (Vector3.Distance(_sister.transform.position, _player.transform.position) >= ChangeDistance)
				{
					_inGameMessage.text = "" + TextForTooMuchDistance;
				}

			}
		}

	}
}
