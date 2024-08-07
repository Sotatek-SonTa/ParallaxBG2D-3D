using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerShooting : NetworkBehaviour
{
    [SerializeField] private GameObject prefabBullet ;
    [SerializeField] private Transform laserTransform;
    void Update()
    {
        if (!IsOwner)
            return;
        if(Input.GetKeyDown(KeyCode.Space)){
            ShootingServerRpc();
        }
    }
    [ServerRpc]
    private void ShootingServerRpc(){
           GameObject newGameObject = Object.Instantiate(prefabBullet,laserTransform.position,Quaternion.identity);
           newGameObject.GetComponent<NetworkObject>().Spawn();
    }
}
