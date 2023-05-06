using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GravityReverseController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private ReversePlayerMovement reversePlayerMovement;

    private void Start()
    {
        playerMovement = this.GetComponent<PlayerMovement>();
        reversePlayerMovement = this.GetComponent<ReversePlayerMovement>();
        Debug.Log(playerMovement.name);
        Debug.Log(reversePlayerMovement.name);
    }

    private enum GravityStates
    {
        standart,
        reverse
    }

    private GravityStates m_GravityStates = GravityStates.standart; 
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Reverse"))
        {
            if (m_GravityStates == GravityStates.standart)
            {
                GetComponent<Rigidbody2D>().gravityScale = -1f;
                playerMovement.enabled = false;
                reversePlayerMovement.enabled = true;
                m_GravityStates = GravityStates.reverse;
            }
            else
            {
                GetComponent<Rigidbody2D>().gravityScale = 1f;
                playerMovement.enabled = true;
                reversePlayerMovement.enabled = false;
                m_GravityStates = GravityStates.standart;
            }
            
        }
       
    }
}
