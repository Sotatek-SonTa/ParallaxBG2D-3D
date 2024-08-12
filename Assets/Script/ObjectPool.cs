using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.Pool;
using System;

public class ObjectPool : NetworkBehaviour
{
    public static ObjectPool Instance {get;private set;}
    public GameObject bulletPrefab;
    public Dictionary<GameObject,ObjectPool<NetworkObject>> poolOjbects = new Dictionary<GameObject, ObjectPool<NetworkObject>>();
    private void Awake() {
        if(Instance!=null&&Instance!=this){
            Destroy(gameObject);
        }
        else{
            Instance = this;
        }
    }
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        RegisterPrefabInternal(bulletPrefab,2000);

    }
    private void RegisterPrefabInternal(GameObject prefab,int poolCapacity){
        NetworkObject CreateFunc(){
            return Instantiate(prefab).GetComponent<NetworkObject>();
        }
        void ActionOnGet(NetworkObject networkObject){
            networkObject.gameObject.SetActive(true);
        }
        void ActionOnRelease(NetworkObject networkObject){
            networkObject.gameObject.SetActive(false);
        }
        void ActionOnDestroy(NetworkObject networkObject){
            Destroy(networkObject.gameObject);
        }
        
        poolOjbects[prefab] = new ObjectPool<NetworkObject>(CreateFunc,ActionOnGet,ActionOnRelease,ActionOnDestroy,maxSize:poolCapacity);
    }
}
