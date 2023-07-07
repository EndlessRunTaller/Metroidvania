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
    private Action<InputAction.CallbackContext> isShooting;
    public Muros muro1, muro2,muro3,muro4;

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

        controls.MovimientoNormal.Grafiti.performed += GRAFITI1;
        controls.MovimientoNormal.Grafiti.canceled += GRAFITI1;

        controls.MovimientoNormal.Grafiti.performed += GRAFITI2;
        controls.MovimientoNormal.Grafiti.canceled += GRAFITI2;

        controls.MovimientoNormal.Grafiti.performed += GRAFITI3;
        controls.MovimientoNormal.Grafiti.canceled += GRAFITI3;
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
            
        }
    }

    private void GRAFITI(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (muro1.InGraffiti)
            {
                muro1.hacerGrafiti = true;
            }
        }
        else if (context.canceled)
        {
            muro1.hacerGrafiti = false;
        }
    }

    private void GRAFITI1(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (muro2.InGraffiti)
            {
                muro2.hacerGrafiti = true;
            }
        }
        else if (context.canceled)
        {
            muro2.hacerGrafiti = false;
        }
    }

    private void GRAFITI2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (muro3.InGraffiti)
            {
                muro3.hacerGrafiti = true;
            }
        }
        else if (context.canceled)
        {
            muro3.hacerGrafiti = false;
        }
    }

    private void GRAFITI3(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (muro4.InGraffiti)
            {
                muro4.hacerGrafiti = true;
            }
        }
        else if (context.canceled)
        {
            muro4.hacerGrafiti = false;
        }
    }


    public void CambiaTecla()
    {
        controls.MovimientoNormal.Enable();
        controls.UI.Disable();
    }


}
