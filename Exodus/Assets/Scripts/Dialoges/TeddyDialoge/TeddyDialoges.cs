using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TeddyDialoges : MonoBehaviour
{
    public List<string> Keys;
    public List<string> Values;

    void Awake()
    {
        TeddyBase.GetDialoge(Keys, Values);
    }

}
