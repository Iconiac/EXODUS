using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlattformDialoges : MonoBehaviour
{

    public List<string> Keys;
    public List<string> Values;

    void Awake()
    {
        PlattformBase.GetDialoge(Keys, Values);
    }
}
