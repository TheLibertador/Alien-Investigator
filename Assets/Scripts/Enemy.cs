using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 100;


    public void TakeDamage (int damage)
    {
        hp -= damage;

        if (hp <= 0) 
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
