using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private GameObject victoryUI;
    [SerializeField] private GameObject gameplayUI;
    private PlayerInput playerInput;

    private void Start() {
        playerInput = FindObjectOfType<PlayerInput>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && victoryUI != null)
        {
            victoryUI.SetActive(true);
            if (playerInput != null)
            {
                playerInput.enabled = false;
            }
            if (gameplayUI != null)
            {
                gameplayUI.SetActive(false);
            }


            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
