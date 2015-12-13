using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DitchDialoges : MonoBehaviour
{

    public List<string> Keys;
    public List<string> Values;

    void Awake()
    {
        DitchBase.GetDialoge(Keys, Values);
    }
}
