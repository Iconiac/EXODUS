﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathDialoges : MonoBehaviour {

    public List<string> Keys;
    public List<string> Values;

    void Awake()
    {
        PathBase.GetDialoge(Keys, Values);
    }
}
