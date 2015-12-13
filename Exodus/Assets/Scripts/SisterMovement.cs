using UnityEngine;
using System.Collections;

public class SisterMovement : MonoBehaviour 
{
	public NavMeshAgent agent { get; private set; }

    private Animator _anim;
    private AudioSource _audio;
    public bool Walking;
      

//       Animator anim;

	private void Start()
	{
        _audio = GetComponent<AudioSource>();
		agent = GetComponentInChildren<NavMeshAgent>();
		agent.updateRotation = true;
		agent.updatePosition = true;
        _anim = GetComponent<Animator>();
	}

	private void Update()
	{
		if (Input.GetMouseButton (0)) 
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			
			if (Physics.Raycast(ray, out hit, Mathf.Infinity))
			{
				agent.destination = hit.point;
			}

            //               anim.SetBool("IsWalking", true);
        }
        if (agent.remainingDistance >= agent.stoppingDistance)
        {
            Walking = true;
            if (!_audio.isPlaying)
            {
                _audio.Play();
            }
        }

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            Walking = false;
        }
        _anim.SetBool("IsWalking", Walking);

    }
}


