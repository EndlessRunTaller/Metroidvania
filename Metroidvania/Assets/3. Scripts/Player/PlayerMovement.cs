using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Velocidades")]
    public float speed;
    private bool derecha;

    public float jumpForce;
    Vector2 dir;
    [Header("Rigibody")]
    public Rigidbody rb;

    [Header("isGrounded")]
    public bool isGrounded;
    public LayerMask whatIsGround;
    public float rayDistanceGround;
    public Transform objGround;

    [Header("Dash")]
    [SerializeField] private float velocidadDash;
    [SerializeField] private float tiempoDash;

    private bool puedeDash = true;
    private bool puedeMover = true;

    [Header("GIRAR")]
    float rotacionJugador;
    float yR = 10;

    private void Start()
    {
        rotacionJugador = transform.rotation.y;
    }

    private void Update()
    {
        ISGROUNDED();
        GIRAR();
        if (Input.GetKeyDown(KeyCode.F) && puedeDash)
        {
            StartCoroutine(DASH());
        }

    }

    private void FixedUpdate()
    {
        if (puedeMover)
        {
            rb.AddForce(new Vector2(dir.x, 0) * speed); //Movieminto tipo gta
        }
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
        Debug.DrawRay(objGround.position, objGround.forward * rayDistanceGround, Color.red);

        RaycastHit hit;

        if (Physics.Raycast(objGround.position, objGround.forward, out hit, rayDistanceGround, whatIsGround))
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
        if(rb.velocity.x > -0.1f)
        {
            derecha = true;
        }
        else
        {
            derecha = false;
        }

        if (derecha)
        {
            rotacionJugador += yR;

            rotacionJugador = Mathf.Clamp(0, 0, 0);

            transform.rotation = Quaternion.Euler(0, rotacionJugador, 0);
        }
        else
        {
            rotacionJugador -= yR;

            rotacionJugador = Mathf.Clamp(0, 180, 0);

            transform.rotation = Quaternion.Euler(0, rotacionJugador, 0);
        }

        Debug.Log(derecha);
        
    }

    public void LIMITARVELOCIDAD()
    {
        if (puedeMover)
        {
            float maxVelocity = 5;

            float velocidadActual = rb.velocity.x; // Obtiene la velocidad actual en el eje X

            // Utiliza Mathf.Clamp para limitar la velocidad en el rango permitido
            float velocidadLimitada = Mathf.Clamp(velocidadActual, -maxVelocity, maxVelocity);

            // Crea un nuevo vector de velocidad limitado en el eje X
            Vector3 nuevaVelocidad = new Vector3(velocidadLimitada, rb.velocity.y, rb.velocity.z);

            // Asigna la nueva velocidad limitada al Rigidbody
            rb.velocity = nuevaVelocidad;
        }
        else
        {
            float maxVelocity = 30;

            float velocidadActual = rb.velocity.x; // Obtiene la velocidad actual en el eje X

            // Utiliza Mathf.Clamp para limitar la velocidad en el rango permitido
            float velocidadLimitada = Mathf.Clamp(velocidadActual, -maxVelocity, maxVelocity);

            // Crea un nuevo vector de velocidad limitado en el eje X
            Vector3 nuevaVelocidad = new Vector3(velocidadLimitada, rb.velocity.y, rb.velocity.z);

            // Asigna la nueva velocidad limitada al Rigidbody
            rb.velocity = nuevaVelocidad;
        }

    }

    private IEnumerator DASH()
    {
        puedeMover = false;
        puedeDash = false;
        rb.constraints = RigidbodyConstraints.FreezePositionY;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        if (derecha)
        {
            rb.velocity = new Vector3(velocidadDash, 0, 0);
        }
        else
        {
            rb.velocity = new Vector3(-velocidadDash, 0, 0);
        }

        yield return new WaitForSeconds(tiempoDash);
        puedeMover = true;
        puedeDash = true;
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    } 
}
