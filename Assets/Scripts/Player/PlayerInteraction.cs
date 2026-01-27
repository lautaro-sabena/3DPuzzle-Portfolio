using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Interaction Settings")]
    [SerializeField] private float interactionRange = 2f;
    [SerializeField] private LayerMask interactableLayer;

    [Header("Raycast Settings")]
    [SerializeField] private Transform cameraTransform;

    private IInteractable currentInteractable;

    public System.Action OnInteractableDetected;
    public System.Action OnInteractableLost;

    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    void Update()
    {
        DetectInteractable();
        HandleInput();
    }

    private void HandleInput()
    {
        if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            TryInteract();
        }
    }

    private void DetectInteractable()
    {
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactionRange, interactableLayer))
        {
            if (hit.collider.TryGetComponent<IInteractable>(out var interactable))
            {
                if (currentInteractable != interactable)
                {
                    currentInteractable = interactable;
                    OnInteractableDetected?.Invoke();
                }
                return;
            }
        }

        ClearCurrentInteractable();
    }

    private void ClearCurrentInteractable()
    {
        if (currentInteractable != null)
        {
            currentInteractable = null;
            OnInteractableLost?.Invoke();
        }
    }

    private void TryInteract()
    {
        if (currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    private void OnDrawGizmos()
    {
        if (cameraTransform != null)
        {
            Gizmos.color = currentInteractable != null ? Color.green : Color.red;
            Gizmos.DrawRay(cameraTransform.position, cameraTransform.forward * interactionRange);
        }
    }
}
