using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour, IValueChangeHandler {

    [SerializeField] private IIntEvent _target;

    public void AddTarget(IIntEvent target)
    {
        _target = target;
    }

    public void UpdateValue(int normalizedValue)
    {
        throw new System.NotImplementedException();
    }

    public void Start()
    {
        _target.SetHandler(this);
    }
}
