using UnityEngine;
using System.Collections;

public class SisterMovement : MonoBehaviour 
{
    private NavMeshAgent _agent;
    private Animator _anim;
    private AudioSource _audio;

    public bool Walking;
      


	private void Start()
	{
        _audio = GetComponent<AudioSource>();
		_agent = GetComponentInChildren<NavMeshAgent>();
		_agent.updateRotation = true;
		_agent.updatePosition = true;
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
				_agent.destination = hit.point;
			}
        }

        if (_agent.remainingDistance >= _agent.stoppingDistance)
        {
            Walking = true;
            _agent.updatePosition = true;

            if (!_audio.isPlaying)
            {
                _audio.Play();
            }
        }

        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            Walking = false;
            _agent.updatePosition = false;
        }

        _anim.SetBool("IsWalking", Walking);

    }
}


