using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public Transform firePoint;
    public GameObject kayaPrefab;
    public float KayaForce;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject kaya = Instantiate(kayaPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = kaya.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.forward * KayaForce);
    }
    
    
}
