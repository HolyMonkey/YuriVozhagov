using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    void ReciveDamage(int damage);
    void AddHealth(int value);
    int GetHealthValue();
}
