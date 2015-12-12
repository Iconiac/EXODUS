using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartCtrl : MonoBehaviour
{
    public Text DialogeText;

    void Start()
    {
        StartBase.Dctrl = this;
    }
}
