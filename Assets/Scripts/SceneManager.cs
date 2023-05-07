using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Level1Finish"))
        {
            
        }
        if (other.transform.CompareTag("Level2Finish"))
        {
            
        }
        if (other.transform.CompareTag("Level3Finish"))
        {
            
        }
        
    }
}
