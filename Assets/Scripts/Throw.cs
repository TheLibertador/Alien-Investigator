using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public Transform firePoint;
    public GameObject kayaPrefab;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(kayaPrefab, firePoint.position, firePoint.rotation);
    }
    
    
}
