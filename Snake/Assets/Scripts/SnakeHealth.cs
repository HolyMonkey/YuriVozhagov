using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHealth : MonoBehaviour, IHealth, IIntEvent
{
    private IValueChangeHandler _handler;
    private float StartHungerTime = 3;
    private float hungerTime = 3;
    private int _health = 3;
    private int _maxHealth;

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
        _handler.UpdateValue(_health);
    }

    public void SetHandler(IValueChangeHandler handler)
    {
        _handler = handler;
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

            if (_handler != null)
            {
                _handler.UpdateValue(_maxHealth / _health);
            }
        }
    }

    public void AddHealth(int value)
    {
        if (value > 0)
        {
            Health += value;

            if (_handler != null)
            {
                _handler.UpdateValue(_maxHealth / _health);
            }
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
                if (_handler != null)
                {
                    _handler.UpdateValue(_maxHealth / _health);
                }
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
