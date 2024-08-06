using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode.Transports.UTP;
public class UINetwork : MonoBehaviour
{
 [SerializeField] private Button startHostButton;
    [SerializeField] private Button startClientButton;
    [SerializeField] private TMP_InputField hostIpAddressInputField;
    [SerializeField] private TMP_InputField clientIpAddressInputField;
    [SerializeField] private TMP_InputField portInputField;

    private void Awake()
    {
        startHostButton.onClick.AddListener(() =>
        {
            // string ipAddress = hostIpAddressInputField.text;
            // ushort port = ushort.Parse(portInputField.text);

            // var unityTransport = NetworkManager.Singleton.GetComponent<UnityTransport>();
            // unityTransport.ConnectionData.Address = ipAddress;
            // unityTransport.ConnectionData.Port = port;

            NetworkManager.Singleton.StartHost();
        });

        startClientButton.onClick.AddListener(() =>
        {
            // string ipAddress = clientIpAddressInputField.text;
            // ushort port = ushort.Parse(portInputField.text);

            // var unityTransport = NetworkManager.Singleton.GetComponent<UnityTransport>();
            // unityTransport.ConnectionData.Address = ipAddress;
            // unityTransport.ConnectionData.Port = port;

            NetworkManager.Singleton.StartClient();
        });
    }
}
