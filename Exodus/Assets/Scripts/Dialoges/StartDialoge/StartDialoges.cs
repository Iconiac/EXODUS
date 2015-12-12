using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StartDialoges : MonoBehaviour
{

    public List<string> Keys;
    public List<string> Values;

    void Awake()
    {
        StartBase.GetDialoge(Keys, Values);
    }
}
