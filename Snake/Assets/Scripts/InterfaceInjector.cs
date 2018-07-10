using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceInjector : MonoBehaviour {

    public GameObject Handler;
    public GameObject Event;

    public void OnValidate()
    {
        if (Handler.GetComponent<IValueChangeHandler>() == null) Handler = null;
        if (Event.GetComponent<IIntEvent>() == null) Event = null;
    }

    public void Start()
    {
        if (Handler != null && Event != null)
        {
            Event.GetComponent<IIntEvent>().SetHandler(Handler.GetComponent<IValueChangeHandler>());
        }
    }
}
