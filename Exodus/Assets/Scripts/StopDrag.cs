using UnityEngine;
using System.Collections;

public class StopDrag : MonoBehaviour
{
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.CompareTag("Border"))
        {
            StartCoroutine("StopSlide");
        }
    }

    IEnumerator StopSlide()
    {
        yield return new WaitForSeconds(0.1f);
        _rigidbody.isKinematic = true;
        yield return new WaitForSeconds(0.1f);
        _rigidbody.isKinematic = false;
    }
}
