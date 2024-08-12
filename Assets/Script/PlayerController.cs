using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private TextMeshProUGUI healthPointUI;
    [SerializeField] private NetworkVariable<int> healthPoint;
    private void Awake() {
        canvas.worldCamera = Camera.main;
    }
    public override void OnNetworkSpawn(){
        healthPoint.Value = 100;
    }
    private void Update(){
        healthPointUI.text = healthPoint.Value.ToString();
        if(Input.GetKeyDown(KeyCode.Space))
            HealthDrain();
    }
    public void HealthDrain(){
        if (IsOwner)
        {
            HealthDrainServerRpc();
        }
    }
    [ServerRpc]
    private void HealthDrainServerRpc(){
        healthPoint.Value -= 10;
    }

}
