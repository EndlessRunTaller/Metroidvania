using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSystem : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    private Vector2 dir;

    private float rotacionDisparo;
    private float yR = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SHOOT()
    {
        Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
    }

    public void ROTATION(Vector2 rotacion)
    {

    }

}
