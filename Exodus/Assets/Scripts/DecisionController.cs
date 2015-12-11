using UnityEngine;
using System.Collections;

public class DecisionController : MonoBehaviour
{
    [SerializeField] GameObject Mom;
    [SerializeField] GameObject Dad;

    void Start()
    {
        if (DecisionCity._momChosen == true)
        {
            Mom.SetActive(true);
        }

        if (DecisionCity._dadChosen == true)
        {
            Dad.SetActive(true);
        }
    }



}
