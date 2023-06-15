using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Codigos")]
    private Rigidbody rb;
    

    [Header("Velocidades")]
    public float speed;
    private bool derecha;
    private Vector2 dir;


    [Header("isGrounded")]
    public bool isGrounded;
    public LayerMask whatIsGround;
    public float rayDistanceGround;
    public Transform objGround;

    [Header("Dash")]
    [SerializeField] private float velocidadDash;
    [SerializeField] private float tiempoDash;

    public bool puedeDash = true;
    public bool puedeMover = true;

    [Header("GIRAR")]
    private float rotacionJugador;
    private float yR = 10;

    [Header("Jump")]
    public float GravityScale;
    public float jumpForce;

    public float jumpStartTime;
    private float jumpTime;
    private bool isJumping;

    [Header("Shoot")]
    public Vector2 shootPoint;



    private void Start()
    {
        rotacionJugador = transform.rotation.y;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ISGROUNDED();
    }

    private void FixedUpdate()
    {
        if (puedeMover)
        {
            rb.AddForce(new Vector2(dir.x, 0) * speed); //Movieminto tipo gta
        }
        LIMITARVELOCIDAD();

        if (puedeDash)
        {
            GRAVITY(GravityScale);
        }

        StartJump();
        StopJump();
    }

    public void MOVEDIR(Vector2 direction)
    {
        dir = direction;
    }

    //Fases del salto
    public void PERFORMJUMP()
    {
        isJumping = true;
    }

    public void CANCELJUMP()
    {
        isJumping = false;
    }

    public void StartJump()
    {
        if (isJumping && isGrounded)
        {
            GRAVITY(0);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    public void StopJump()
    {
        if (!isJumping && !isGrounded)
        {
            GRAVITY(GravityScale);
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

    public void GIRAR(Vector2 direcction)
    {
        if(direcction.x > 0.5)
        {
            derecha = true;
        }
        else if(direcction.x < -0.5)
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

    public IEnumerator DASH()
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

    public void GRAVITY(float GravityScale)
    {
        rb.AddForce(Physics.gravity * (GravityScale - 1) * rb.mass);
    }
}
