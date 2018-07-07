using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHealth : MonoBehaviour, IHealth {

    IValueChangeHandler _healthDisplay;
    float StartHungerTime = 3;
    float hungerTime = 3;
    int _health = 3;

    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
        }
    }

    private void Start()
    {
        _healthDisplay = GameObject.FindGameObjectWithTag("Display").GetComponent<IValueChangeHandler>();
        _healthDisplay.UpdateValue(_health);
    }

    private void Update()
    {
        GetHunger();
    }

    public void ReciveDamage(int damage)
    {
        if (Health > 0)
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
            _healthDisplay.UpdateValue(_health);
        }
    }

    public void AddHealth(int value)
    {
        if (value > 0)
        {
            Health += value;
            _healthDisplay.UpdateValue(_health);
        }
    }

    void GetHunger()
    {
        StartHungerTime -= Time.deltaTime;
        if (StartHungerTime <= 0)
        {
            Health -= 1;
            if (Health >= 0)
            {
                _healthDisplay.UpdateValue(_health);
            }
            StartHungerTime = hungerTime;
            CheckDeath();
            
        }
    }

    void CheckDeath()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
            Application.Quit();
        }
    }

    public int GetHealthValue()
    {
        return Health;
    }
}
