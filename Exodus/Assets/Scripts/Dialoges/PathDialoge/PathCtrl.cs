using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PathCtrl : MonoBehaviour
{
    public Text DialogeText;
    public List<Text> OptionText;
    public GameObject YesOption;
    public GameObject NoOption;

    void Start()
    {
        PathBase.Dctrl = this;
    }

    public void SetOption(int option)
    {
        if (option == 1)
        {
            PathOptions.Option1 = true;
        }

        else if (option == 2)
        {
            PathOptions.Option2 = true;
        }
    }

}
