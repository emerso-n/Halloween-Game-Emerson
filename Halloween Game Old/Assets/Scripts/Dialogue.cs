﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string myName;

    [TextArea(3, 10)]
    public string[] sentences;

    public GameObject character;
}
