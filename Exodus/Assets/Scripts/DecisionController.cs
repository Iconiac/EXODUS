using UnityEngine;
using System.Collections;

public class DecisionController : MonoBehaviour
{
    [SerializeField] GameObject Mom;
    [SerializeField] GameObject Dad;
    [SerializeField] GameObject DadToolBox;
    [SerializeField] GameObject MomToolBox;

    void Start()
    {
        if (DecisionCity._momChosen == true)
        {
            Mom.SetActive(true);
            MomToolBox.SetActive(true);
        }

        if (DecisionCity._dadChosen == true)
        {
            Dad.SetActive(true);
            DadToolBox.SetActive(true);
        }
    }



}
