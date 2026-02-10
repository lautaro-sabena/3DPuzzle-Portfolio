using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private GameEvent onPressedEvent;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip interactClip;
    private Color originalColor;
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
            if(_renderer != null) originalColor = _renderer.material.color;
    }
    public void Interact()
    {
        if(audioSource != null && interactClip != null) audioSource.PlayOneShot(interactClip);
        StartCoroutine(Flash());
        onPressedEvent?.Raise();
    }

    IEnumerator Flash()
    {
        _renderer.material.color = Color.green;
        yield return new WaitForSeconds(0.1f);
        _renderer.material.color = originalColor;
    }
}
