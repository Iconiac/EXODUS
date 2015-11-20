using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	public class ScreenChangeAlpha : MonoBehaviour 
	{

		[SerializeField] GameObject PositionToSpawnAt;
		[SerializeField] GameObject CameraToActivate;
		[SerializeField] GameObject CameraToDeactivate;
		[SerializeField] GameObject[] EnemiesToActivate;
		[SerializeField] GameObject[] OptionalThingsToActivate;
		[SerializeField] GameObject[] OptionalThingsToDeactivate;
		[SerializeField] string TextToShow;

		private GameObject _sister;
		private GameObject _player;
		private SisterMovement _sisterTarget;
		private Text _inGameMessage;

		void Awake()
		{
			_player = GameObject.Find("Player");
			_sister = GameObject.Find ("LilSister");
			_inGameMessage = GameObject.Find ("InGameText").GetComponent<Text> ();
			_sisterTarget = _sister.GetComponent<SisterMovement>();

		}
			
		void OnCollisionEnter (Collision col)
		{
			if (col.gameObject.tag == "Player")
			{
				Vector3 _sisterPosition = new Vector3 (PositionToSpawnAt.transform.position.x, PositionToSpawnAt.transform.position.y, PositionToSpawnAt.transform.position.z - 2);
				CameraToActivate.SetActive(true);
				_player.transform.position = PositionToSpawnAt.transform.position;
				_sister.GetComponent<NavMeshAgent>().Warp(_sisterPosition);
				_sisterTarget.target = _sister.transform.position;

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

				CameraToDeactivate.SetActive(false);

			}


		}

	}
}
