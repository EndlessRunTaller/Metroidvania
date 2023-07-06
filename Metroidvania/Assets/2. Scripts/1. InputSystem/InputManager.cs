using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    Controls controls;
    public PlayerMovement playerMovement;
    public ShootSystem shootSystem;
    public Grafiti grafiti;
    public bool PuedeGrafiti = false;
    private Action<InputAction.CallbackContext> isShooting;

    private void Awake()
    {
        controls = new Controls();
    }

    public void OnEnable()
    {
        controls.UI.Enable();

        controls.UI.Submit.performed += UI;
        //Movimiento
        controls.MovimientoNormal.Move.performed += MovePlayer;
        controls.MovimientoNormal.Move.canceled += MovePlayer;
        //Salto
        controls.MovimientoNormal.Jump.performed += JumpPlayer;
        controls.MovimientoNormal.Jump.canceled += JumpPlayer;
        //Dash
        controls.MovimientoNormal.Dash.performed += DashPlayer;
        //Shoot
        controls.MovimientoGlitch.Shoot.performed += ShootPlayer;
        controls.MovimientoGlitch.Shoot.canceled += ShootPlayer;
        //isShooting
        controls.MovimientoGlitch.isShooting.performed += ISSHOOTING;
        controls.MovimientoGlitch.isShooting.canceled += ISSHOOTING;

        controls.MovimientoNormal.Grafiti.performed += GRAFITI;
        controls.MovimientoNormal.Grafiti.canceled += GRAFITI;
    }


    private void ISSHOOTING(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            shootSystem.isShooting = true;
        }
        else if (context.canceled)
        {
            shootSystem.isShooting = false;
        }
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

    private void UI(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            grafiti.HacerGrafiti();
        }
    }

    private void GRAFITI(InputAction.CallbackContext context)
    {
        if (context.performed && grafiti.HacerGrafiti())
        {
            grafiti.hacerGrafiti = true;
        }
        else if (context.canceled)
        {
            grafiti.hacerGrafiti = false;
        }
    }

    public void CambiaTecla()
    {
        controls.MovimientoNormal.Enable();
        controls.UI.Disable();
    }
}
