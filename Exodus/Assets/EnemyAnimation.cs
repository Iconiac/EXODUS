using UnityEngine;
using System.Collections;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] GameObject Enemy;

    private Animator _anim;
    private bool _sight;

    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Enemy.GetComponent<SeePlayer>().PlayerInSight == false)
        {
            _sight = true;
        }

        if(Enemy.GetComponent<SeePlayer>().PlayerInSight == true)
        {
            _sight = false;
        }

        _anim.SetBool("IsWalking", _sight);
    }

}
