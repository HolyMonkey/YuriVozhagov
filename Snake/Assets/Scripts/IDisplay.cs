﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public interface IDisplay{

    void DisplayIt(Text target, int value);
    void UpdateValue(int newValue);
}
