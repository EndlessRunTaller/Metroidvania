using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSystem : MonoBehaviour
{
    public Transform shootingPoint;
    public float shootLimit = 5;
    private int shoots;
    public GameObject bulletPrefab;
    public Animator anim;
    private Vector2 dir;
    public float speed;

 
    public bool isShooting;
    public bool canShoot;

    public bool grado0;
    public bool grado0Disparo;



    // Update is called once per frame
    void Update()
    {
        anim.SetBool("grado0", isShooting);
    }

    public void ANIMACION(Vector2 shootDir)
    {
        if (shootDir.x == 1 || shootDir.x == -1)
        {
            grado0Disparo = true;
        }
        else
        {
            grado0Disparo = false;
        }
    }

    public void SHOOT()
    {
        var bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = shootingPoint.right * speed;
    }
}
