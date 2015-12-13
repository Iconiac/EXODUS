using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
    [SerializeField] float Speed;

    private NavMeshAgent _agent;
    private GameObject _cam;
    private Animator _anim;
    private AudioSource _audio;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
        Cursor.visible = true;
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        _cam = GameObject.Find("Camera");

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h != 0)
        {
            _agent.Move(_cam.transform.right * Time.deltaTime * Speed * h);
            if (!_audio.isPlaying)
            {
                _audio.Play();
            }
            transform.forward = _cam.transform.TransformDirection(new Vector3(h, 0f, v));
        }

        if (v != 0)
        {
            _agent.Move(_cam.transform.forward * Time.deltaTime * Speed * v);
            if (!_audio.isPlaying)
            {
                _audio.Play();
            }
            transform.forward = _cam.transform.TransformDirection(new Vector3(h, 0f, v));
        }

        /*  if (Input.GetButton("Interact"))
        {
            anim.SetTrigger("Interact", interactOn);
        }
        */
        Animating(h, v);
    }

    void Animating(float h, float v)
    {
            bool walking = h != 0f || v != 0f;
            bool sneaking = Input.GetButton("Stealth");
        if(_agent.enabled == false)
        {
            walking = false;
        }
            _anim.SetBool("IsWalking", walking);
            _anim.SetBool("IsSneaking", sneaking);
    }
}
