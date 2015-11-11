using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	public class ScreenChangeAlpha : MonoBehaviour 
	{
		public GameObject startScreenBorderRight;
		public GameObject startScreenBorderLeft;
		public GameObject screen2BorderRight;
		public GameObject screen2BorderLeft;
		public GameObject spawnScreen2Right;
		public GameObject spawnScreen3Right;
		public GameObject spawnScreen3Left;
		public GameObject spawnScreen2Left;

		public GameObject camStart;
		public GameObject camScreen2;
		public GameObject camScreen3Dad;
		public GameObject camScreen3Mom;

		public GameObject sister;
		public GameObject carEnemy;
		public GameObject houseEnemy;

		private bool dadChosen;
		private bool momChosen;
			
		void OnCollisionEnter (Collision col)
		{
			if (col.gameObject == startScreenBorderRight)
			{
				camStart.SetActive(false);
				camScreen2.SetActive(true);
				dadChosen = true;
				transform.position = new Vector3 (spawnScreen2Left.transform.position.x, transform.position.y, spawnScreen2Left.transform.position.z);
				sister.transform.position = new Vector3 (spawnScreen2Left.transform.position.x, transform.position.y, spawnScreen2Left.transform.position.z - 2);
				sister.GetComponent<SisterMovement>().target = sister.transform.position;
				GetComponent<DialogueController>().StoryText();
				carEnemy.GetComponent<SeePlayer>().enabled = true;
				houseEnemy.GetComponent<SeePlayer>().enabled = true;

			}

			if (col.gameObject == startScreenBorderLeft)
			{
				camStart.SetActive(false);
				camScreen2.SetActive(true);
				momChosen = true;
				transform.position = new Vector3 (spawnScreen2Right.transform.position.x, transform.position.y, spawnScreen2Right.transform.position.z);
				sister.transform.position = new Vector3 (spawnScreen2Right.transform.position.x, transform.position.y, spawnScreen2Right.transform.position.z - 2);
				sister.GetComponent<SisterMovement>().target = sister.transform.position;
				GetComponent<DialogueController>().StoryText();
				carEnemy.GetComponent<SeePlayer>().enabled = true;
				houseEnemy.GetComponent<SeePlayer>().enabled = true;
			}

			if (dadChosen == true)
			{
				if (col.gameObject == screen2BorderRight)
				{
					camScreen2.SetActive(false);
					camScreen3Dad.SetActive(true);
					transform.position = new Vector3 (spawnScreen3Left.transform.position.x, transform.position.y, spawnScreen3Left.transform.position.z);
					sister.transform.position = new Vector3 (spawnScreen3Left.transform.position.x, transform.position.y, spawnScreen3Left.transform.position.z);
					sister.GetComponent<SisterMovement>().target = sister.transform.position;
				}
			}

			if (momChosen == true)
			{
				if (col.gameObject == screen2BorderLeft)
				{
					camScreen2.SetActive(false);
					camScreen3Mom.SetActive(true);
					transform.position = new Vector3 (spawnScreen3Right.transform.position.x, transform.position.y, spawnScreen3Right.transform.position.z);
					sister.transform.position = new Vector3 (spawnScreen3Right.transform.position.x, transform.position.y, spawnScreen3Right.transform.position.z);
					sister.GetComponent<SisterMovement>().target = sister.transform.position;
				}
			}
		}

	}
}
