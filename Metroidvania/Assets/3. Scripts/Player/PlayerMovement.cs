using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Velocidades")]
    public float speed;
    public float maxSpeed;
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
        GIRAR();

        rb.AddForce(new Vector2(dir.x, 0) * speed * Time.deltaTime);
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

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

        Debug.Log(isGrounded);
    }

    public void GIRAR()
    {
        if(rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
