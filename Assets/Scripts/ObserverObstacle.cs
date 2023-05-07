using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverObstacle : MonoBehaviour
{
   private List<Transform> observers;

   private void Start()
   {
      for (int i = 0; i < GetComponentsInChildren<Transform>().Length; i++)
      {
         if (i != 0)
         {
            observers.Add(transform.GetComponentsInChildren<Transform>()[i]);
         }
      }
   }

   private void FixedUpdate()
   {
      StartCoroutine(ObstacleBehaviour());
   }

   private IEnumerator ObstacleBehaviour()
   {
      foreach (var observer in observers)
      {
         observer.gameObject.SetActive(true);
      }
      yield return new WaitForSeconds(1f);
      foreach (var observer in observers)
      {
         observer.gameObject.SetActive(false);
      }
      yield return new WaitForSeconds(2f);
      foreach (var observer in observers)
      {
         observer.gameObject.SetActive(true);
      }
      
   }
}
