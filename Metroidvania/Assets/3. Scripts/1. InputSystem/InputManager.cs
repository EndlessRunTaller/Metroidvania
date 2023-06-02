using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    Controls controls;

    private void Awake()
    {
        controls = new Controls();
    }

    private void OnEnable()
    {
        controls.Movimiento.Enable();
        controls.Movimiento.Move.performed += MovePlayer;
        controls.Movimiento.Move.canceled += MovePlayer;
        controls.Movimiento.Jump.started += JumpPlayer;
    }

    private void JumpPlayer(InputAction.CallbackContext obj)
    {
        FindObjectOfType<PlayerMovement>().JUMPPLAYER();
    }

    private void MovePlayer(InputAction.CallbackContext obj)
    {
        Vector2 moveDir = obj.ReadValue<Vector2>();
        FindObjectOfType<PlayerMovement>().MOVEDIR(moveDir);
    }
}
