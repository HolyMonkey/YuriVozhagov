using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public interface IIntEvent
{
    void SetHandler(IValueChangeHandler handler);
}

