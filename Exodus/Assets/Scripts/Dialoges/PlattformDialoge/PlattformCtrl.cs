using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlattformCtrl : MonoBehaviour
{
    public Text DialogeText;

    void Start()
    {
        PlattformBase.Dctrl = this;
    }
}
 