using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField]private float parrlaxEffectSpeed;

    private float length;

    private float startPos;
    private void Start(){
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    private void Update(){
        
    }
    private void FixedUpdate(){
        transform.Translate(Vector3.left*parrlaxEffectSpeed*Time.deltaTime);
        if(transform.position.x < startPos - length){
             transform.position = Vector3.right*startPos *length;
        }
    }
}
