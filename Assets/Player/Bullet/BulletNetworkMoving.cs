using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.VisualScripting;

public class BulletNetworkMoving : NetworkBehaviour
{
    [SerializeField] private float movingSpeed = 2f;
    Vector3 vector3 = Vector3.right;
    void FixedUpdate(){
        transform.Translate(movingSpeed*vector3*Time.deltaTime);
    }
}
