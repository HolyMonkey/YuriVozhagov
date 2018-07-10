using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StringDisplay : MonoBehaviour, IValueChangeHandler {

    private Text _display;
    private int _value;

    public void UpdateValue(int newValue)
    {
        _value = newValue;
        DisplayIt(_display, _value);
    }

    private void DisplayIt(Text target, int value)
    {
        target.text = value.ToString();
    }

    private void Start ()
    {
        _display = gameObject.GetComponent<Text>();
    }
	
}
