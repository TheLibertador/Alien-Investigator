using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offSet = new Vector3(1f, 2f, 0);


    private void LateUpdate()
    {
        this.transform.position = new Vector3(target.position.x, target.position.y + offSet.y, transform.position.z);
    }
}
