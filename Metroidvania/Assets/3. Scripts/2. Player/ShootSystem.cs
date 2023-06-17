using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSystem : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    private Animator anim;
    private Vector2 dir;

    private float rotacionDisparo;
    private float yR = 10;

    //BOOLS
    private bool grado0;
    private bool grado45;
    private bool grado90;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SHOOT()
    {
        Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
    }

    public void ANIMACION(Vector2 shootDir)
    {
        if (shootDir.x == 1)
        {
            grado0 = true;
            grado45 = false;
            grado90 = false;
        } else if (shootDir.x >= 0.5f && shootDir.x <= 0.8)
        {
            grado0 = false;
            grado45 = true;
            grado90 = false;
        }
        else if(shootDir.y == 1)
        {
            grado0 = false;
            grado45 = false;
            grado90 = true;
        }
        else
        {
            grado0 = false;
            grado45 = false;
            grado90 = false;
        }
        
        anim.SetBool("grado0", grado0);
        anim.SetBool("grado45", grado45);
        anim.SetBool("grado90", grado90);
    }

}
