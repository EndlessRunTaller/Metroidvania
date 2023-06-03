using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Velocidades")]
    public float speed;
    public float maxVelocity;
    public float jumpForce;
    Vector2 dir;
    [Header("Rigibody")]
    public Rigidbody rb;

    [Header("isGrounded")]
    public bool isGrounded;
    public LayerMask whatIsGround;
    public float rayDistance;
    public Transform objRaycast;


    private void Update()
    {
        ISGROUNDED();
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(dir.x, 0) * speed); //Movieminto tipo gta
        //rb.velocity = new Vector2(dir.x * speed, 0); //MovimientoNormal

        LIMITARVELOCIDAD();
    }

    public void MOVEDIR(Vector2 direction)
    {
        dir = direction;
    }

    public void JUMPPLAYER()
    {
        if (isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    public void ISGROUNDED()
    {
        Debug.DrawRay(objRaycast.position, objRaycast.forward * rayDistance, Color.red);

        RaycastHit hit;

        if (Physics.Raycast(objRaycast.position, objRaycast.forward, out hit, rayDistance, whatIsGround))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    public void GIRAR()
    {
        if (rb.velocity.x > -0.1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void LIMITARVELOCIDAD()
    {
        float velocidadActual = rb.velocity.x; // Obtiene la velocidad actual en el eje X

        // Utiliza Mathf.Clamp para limitar la velocidad en el rango permitido
        float velocidadLimitada = Mathf.Clamp(velocidadActual, -maxVelocity, maxVelocity);

        // Crea un nuevo vector de velocidad limitado en el eje X
        Vector3 nuevaVelocidad = new Vector3(velocidadLimitada, rb.velocity.y, rb.velocity.z);

        // Asigna la nueva velocidad limitada al Rigidbody
        rb.velocity = nuevaVelocidad;
    }
}
