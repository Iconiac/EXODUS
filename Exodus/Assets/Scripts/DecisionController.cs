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
        if (Decisions.MomChosen == true)
        {
            Mom.SetActive(true);
            MomToolBox.SetActive(true);
        }

        if (Decisions.DadChosen == true)
        {
            Dad.SetActive(true);
            DadToolBox.SetActive(true);
        }
    }



}
