using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour, IDisplay {

    Text _healthText;
    int _healthValue;

    public void DisplayIt(Text target, int value)
    {
        target.text = value.ToString();
    }

    public void UpdateValue(int newValue)
    {
        _healthValue = newValue;
        DisplayIt(_healthText, _healthValue);
    }

    // Use this for initialization
    void Start ()
    {
        _healthText = gameObject.GetComponent<Text>();
    }
	
}
