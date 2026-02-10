using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float speed = 2f;

    private Vector3 target;
    private bool active;

    void Start()
    {
        transform.position = pointA.position;
        target = pointA.position;
    }

    void Update()
    {
        if (!active) return;
        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            speed * Time.deltaTime
        );
    }

    public void MoveToB()
    {
        active = true;
        target = pointB.position;
    }

    public void MoveToA()
    {
        active = true;
        target = pointA.position;
    }
}
