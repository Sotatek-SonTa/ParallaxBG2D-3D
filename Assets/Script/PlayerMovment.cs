using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerMovment : NetworkBehaviour
{
  [SerializeField] public float moveSpeed = 5f;

  private Vector3 otherPos;

  // Start is called before the first frame update
  void Start()
  {

  }

  void FixedUpdate()
  {
    if (IsOwner)
    {
      var horizontal = Input.GetAxis("Horizontal");
      var vertical = Input.GetAxis("Vertical");
      Vector3 newposition = new Vector3(horizontal, vertical, 0);
      transform.position += moveSpeed * newposition * Time.deltaTime;

      if (NetworkManager.Singleton.IsClient)
      {
        // Gọi RPC để cập nhật vị trí cho máy chủ
        SyncPlayerPosServerRpc(transform.position);
      }
    }
    else
    {
      // Cập nhật vị trí cho các client không sở hữu object này
      transform.position = otherPos;
    }
  }

  [ServerRpc]
  void SyncPlayerPosServerRpc(Vector3 pos)
  {
    // Cập nhật vị trí trên máy chủ
    otherPos = pos;
    
    // Gọi ClientRpc để đồng bộ hóa vị trí trên các client khác
    SyncPlayerPosClientRpc(pos);
  }

  [ClientRpc]
  void SyncPlayerPosClientRpc(Vector3 pos)
  {
    // Cập nhật vị trí cho các client khác (không phải client sở hữu object này)
    if (!IsOwner)
    {
      otherPos = pos;
    }
  }
}
