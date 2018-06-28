using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingEat : MonoBehaviour, IFoodLogic {

    public int HealValue = 1;

    public void Do(Snake snake)
    {
        snake.Health += HealValue;
    }
}
