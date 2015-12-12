using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
    [SerializeField] float Speed;

    private NavMeshAgent _agent;
    private GameObject _cam;

    Animator anim;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        _cam = GameObject.Find("Camera");

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h != 0)
        {
            _agent.Move(_cam.transform.right * Time.deltaTime * Speed * h);
            transform.forward = _cam.transform.TransformDirection(new Vector3(h, 0f, v));
        }

        if (v != 0)
        {
            _agent.Move(_cam.transform.forward * Time.deltaTime * Speed * v);
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
        anim.SetBool("IsWalking", walking);

        if (Input.GetButton("Stealth"))
        {
            bool sneaking = h != 0f || v != 0f;
            anim.SetBool("IsSneaking", sneaking);
        }
    }
}
