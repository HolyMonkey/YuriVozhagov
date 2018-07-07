using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StringDisplay : MonoBehaviour, IValueChangeHandler, IDisplay {

    Text _display;
    int _value;

    public void DisplayIt(Text target, int value)
    {
        target.text = value.ToString();
    }

    public void UpdateValue(int newValue)
    {
        _value = newValue;
        DisplayIt(_display, _value);
    }

    // Use this for initialization
    void Start ()
    {
        _display = gameObject.GetComponent<Text>();
    }
	
}
