using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerMovment : NetworkBehaviour
{
    [SerializeField]public float moveSpeed =5f; 
    
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
