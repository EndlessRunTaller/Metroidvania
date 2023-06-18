using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    Controls controls;
    public PlayerMovement playerMovement;

    private void Awake()
    {
        controls = new Controls();
    }

    private void OnEnable()
    {
        controls.Movimiento.Enable();
        //Movimiento
        controls.Movimiento.Move.performed += MovePlayer;
        controls.Movimiento.Move.canceled += MovePlayer;
        //Salto
        controls.Movimiento.Jump.performed += JumpPlayer;
        controls.Movimiento.Jump.canceled += JumpPlayer;
        //Dash
        controls.Movimiento.Dash.performed += DashPlayer;
        //Shoot
        controls.Movimiento.Shoot.performed += ShootPlayer;
        controls.Movimiento.Shoot.canceled += ShootPlayer;
    }



    private void DashPlayer(InputAction.CallbackContext obj)
    {
        if (playerMovement.puedeDash)
        {
            FindObjectOfType<PlayerMovement>().StartCoroutine(playerMovement.DASH());
        }     
    }

    private void JumpPlayer(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            FindObjectOfType<PlayerMovement>().PERFORMJUMP();
        }
        if (context.canceled)
        {
            FindObjectOfType<PlayerMovement>().CANCELJUMP();
        }
    }

    private void MovePlayer(InputAction.CallbackContext obj)
    {
        Vector2 moveDir = obj.ReadValue<Vector2>();
        FindObjectOfType<PlayerMovement>().MOVEDIR(moveDir);
        FindObjectOfType<PlayerMovement>().GIRAR(moveDir);
    }

    private void ShootPlayer(InputAction.CallbackContext obj)
    {
        Vector2 shootDir = obj.ReadValue<Vector2>();
        FindObjectOfType<ShootSystem>().ANIMACION(shootDir);
    }

}
