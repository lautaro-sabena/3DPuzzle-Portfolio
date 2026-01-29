using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlatformMotor : MonoBehaviour
{
    private CharacterController controller;
    private MovingPlatform currentPlatform;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void LateUpdate()
    {
        if (currentPlatform != null && currentPlatform.IsMoving)
        {
            controller.Move(currentPlatform.Delta);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.TryGetComponent(out MovingPlatform platform))
        {
            currentPlatform = platform;
        }
        else if (currentPlatform != null)
        {
            if (!IsStandingOnPlatform())
            {
                currentPlatform = null;
            }
        }
    }

    private bool IsStandingOnPlatform()
    {
        if (currentPlatform == null) return false;

        RaycastHit hit;
        Vector3 origin = transform.position;
        float rayDistance = controller.height / 2 + controller.skinWidth + 0.1f;

        if (Physics.Raycast(origin, Vector3.down, out hit, rayDistance))
        {
            return hit.collider.gameObject == currentPlatform.gameObject;
        }

        return false;
    }
}
