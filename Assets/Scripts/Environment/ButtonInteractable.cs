using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private GameEvent onPressedEvent;
    public void Interact()
    {
        Debug.Log("Button pressed");
        GetComponent<Renderer>().material.color = Color.green;
        onPressedEvent?.Raise();
    }
}
