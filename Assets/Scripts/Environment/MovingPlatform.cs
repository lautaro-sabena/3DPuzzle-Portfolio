using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private float moveSpeed = 2f;

    private Vector3 lastPosition;
    public Vector3 Delta { get; private set; }

    [Header("Events")]
    [SerializeField] private GameEvent activateEvent;
    [SerializeField] private GameEvent callEvent;

    private bool isActive;
    public bool IsMoving { get; private set; }
    private Vector3 targetPosition;
    private bool movingToEnd = true;

    private void Awake()
    {
        if (startPoint != null)
            transform.position = startPoint.position;
        lastPosition = transform.position;
        targetPosition = endPoint.position;
    }

    private void OnEnable()
    {
        if (activateEvent != null)
            activateEvent.RegisterListener(Activate);
        if (callEvent != null)
            callEvent.RegisterListener(Call);
        lastPosition = transform.position;
    }

    private void OnDisable()
    {
        if (activateEvent != null)
            activateEvent.UnregisterListener(Activate);
        if (callEvent != null)
            callEvent.UnregisterListener(Call);
    }

    private void Update()
    {
        if (!isActive) return;

        Vector3 previousPosition = transform.position;
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            isActive = false;
            IsMoving = false;
            
            movingToEnd = !movingToEnd;
            targetPosition = movingToEnd ? endPoint.position : startPoint.position;
        }
        else
        {
            IsMoving = true;
        }
    }

    void LateUpdate()
    {
        Delta = transform.position - lastPosition;
        lastPosition = transform.position;
    }

    private void Activate()
    {
        isActive = true;
    }

    private void Call()
    {
        if (!movingToEnd && !IsMoving)
        {
            isActive = true;
        }
    }

}