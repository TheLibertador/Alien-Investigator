using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private List<GameObject> FirstTeleportPair;
    [SerializeField] private List<GameObject> SecondTeleportPair;

    private Animator animator;

    private void Start()
    {
         animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
     {
          if(other.CompareTag("FirstTeleport"))
          {
               StartCoroutine(TeleportAnimation());
               if (other.gameObject == FirstTeleportPair[0])
               {
                    gameObject.transform.position = FirstTeleportPair[1].transform.position;
                    StartCoroutine(TeleportCoolDown(FirstTeleportPair[1]));
               }
               else
               {
                    gameObject.transform.position = FirstTeleportPair[0].transform.position;
                    StartCoroutine(TeleportCoolDown(FirstTeleportPair[0]));
               }
                    
               
          }
          else if (other.CompareTag("SecondTeleport"))
          {
               StartCoroutine(TeleportAnimation());
               if (other.gameObject == SecondTeleportPair[0])
               {
                    gameObject.transform.position = SecondTeleportPair[1].transform.position;
                    StartCoroutine(TeleportCoolDown(SecondTeleportPair[1]));
               }
               else
               {
                    gameObject.transform.position = SecondTeleportPair[0].transform.position;
                    StartCoroutine(TeleportCoolDown(SecondTeleportPair[0]));
               }
          }
          
              
     }

    private IEnumerator TeleportAnimation()
    {
         animator.SetBool("FadeIn", true);
         yield return new WaitForSeconds(0.3f);
         animator.SetBool("FadeIn", false);
         animator.SetBool("FadeOut", true);
         yield return new WaitForSeconds(0.3f);
         animator.SetBool("FadeOut", false);
         
         
         
    }

     private IEnumerator TeleportCoolDown(GameObject pad)
     {
          pad.GetComponent<BoxCollider2D>().enabled = false;
          yield return new WaitForSeconds(3f);
          pad.GetComponent<BoxCollider2D>().enabled = true;
     }
} 
