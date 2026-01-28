using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Game Event")]
public class GameEvent : ScriptableObject
{
    private UnityEvent listeners = new UnityEvent();

    public void Raise()
    {
        listeners.Invoke();
    }

    public void RegisterListener(UnityAction listener)
    {
        listeners.AddListener(listener);
    }

    public void UnregisterListener(UnityAction listener)
    {
        listeners.RemoveListener(listener);
    }
}
