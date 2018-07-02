using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFood : MonoBehaviour, IFoodLogic
{
    public void Do(Snake snake)
    {
        foreach (var bone in snake.Tail)
        {
            bone.GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
    }
}
