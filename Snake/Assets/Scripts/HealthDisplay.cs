using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {
    public Text HealthText;
    IHealth snakeHealth;
	// Use this for initialization
	void Start ()
    {
        snakeHealth = GameObject.FindGameObjectWithTag("Snake").GetComponent<IHealth>();
        HealthText = gameObject.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        HealthText.text = snakeHealth.GetHealthValue().ToString();               
    }
}
