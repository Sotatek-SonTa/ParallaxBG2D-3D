using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerMovment : NetworkBehaviour
{
    [SerializeField]public float moveSpeed =5f; 
    [SerializeField]private Animator animator;
    
    private Vector3 otherPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
      if(IsOwner)
      {
         var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        if(vertical >0f){
           animator.SetBool("isUp",true);
        } else {
          animator.SetBool("isUp",false);
        }
        if(vertical <0f){
          animator.SetBool("isDown",true);
        }else{
          animator.SetBool("isDown",false);
        }
        Vector3 newposition = new Vector3(horizontal,vertical,0);
        transform.position += moveSpeed*newposition*Time.deltaTime;
        if(NetworkManager.Singleton.IsClient){
               SyncPlayerPosServerRpc(transform.position);
        }
      }
      else
      {
        transform.position = otherPos;
      }
    }
    [ServerRpc]
    void SyncPlayerPosServerRpc(Vector3 pos){
         otherPos = pos;
    }
}
