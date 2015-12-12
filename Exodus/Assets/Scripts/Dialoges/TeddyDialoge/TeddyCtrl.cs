using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TeddyCtrl : MonoBehaviour
{

    public Text DialogeText;
    public List<Text> OptionText;
    public GameObject YesOption;
    public GameObject NoOption;

    void Start()
    {
        TeddyBase.Dctrl = this;
    }

    public void SetOption(int option)
    {
        if (option == 1)
        {
            Options.Option1 = true;
        }

        else if (option == 2)
        {
            Options.Option2 = true;
        }
    }

}
