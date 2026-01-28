using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Door Settings")]
    [SerializeField] private DoorState initialState = DoorState.Closed;
    [SerializeField] private float openHeight = 3f;
    [SerializeField] private float openSpeed = 2f;
    [SerializeField] private GameEvent openDoorEvent;

    private DoorState currentState;
    private Vector3 closedPosition;
    private Vector3 openPosition;

    private void Awake()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + Vector3.up * openHeight;
        currentState = initialState;
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (currentState == DoorState.Open)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                openPosition,
                Time.deltaTime * openSpeed
            );
        }
        else if (currentState == DoorState.Closed)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                closedPosition,
                Time.deltaTime * openSpeed
            );
        }
    }

    public void Open()
    {
        if (currentState == DoorState.Locked) return;
        currentState = DoorState.Open;
        Debug.Log($"{name} opened");
    }

    public void Close()
    {
        currentState = DoorState.Closed;
    }

    public void Toggle()
    {
        if (currentState == DoorState.Open)
            Close();
        else
            Open();
    }

    private void OnEnable()
    {
        if (openDoorEvent != null)
            openDoorEvent.RegisterListener(Open);
    }

    private void OnDisable()
    {
        if (openDoorEvent != null)
            openDoorEvent.UnregisterListener(Open);
    }
}
