using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    private GameObject mainMenuUI;
    private PlayerInput playerInput;

    private bool menuActive = true;

    private void Awake() {
        playerInput = FindObjectOfType<PlayerInput>();
        mainMenuUI = this.gameObject;
    }

    void Start()
    {
        if (playerInput != null)
        {
            playerInput.enabled = false;
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        if (menuActive && Keyboard.current != null)
        {
            if (Keyboard.current.anyKey.wasPressedThisFrame)
            {
                StartGame();
            }
        }
    }

    private void StartGame()
    {
        menuActive = false;

        if (mainMenuUI != null)
        {
            mainMenuUI.SetActive(false);
        }

        if (playerInput != null)
        {
            playerInput.enabled = true;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
