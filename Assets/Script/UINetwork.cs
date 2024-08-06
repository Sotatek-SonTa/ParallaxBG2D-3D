using System.Collections;
using System.Collections.Generic;
using System.Net;
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
            string localIP = GetLocalIPAddress();
            Debug.Log("Local IP Address: " + localIP);
            string ipAddress = GetLocalIPAddress();
            hostIpAddressInputField.text = GetLocalIPAddress();
            // ushort port = ushort.Parse(portInputField.text);

            var unityTransport = NetworkManager.Singleton.GetComponent<UnityTransport>();
            unityTransport.ConnectionData.Address = ipAddress;
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

            NetworkManager.Singleton.GetComponent<UnityTransport>().ConnectionData.Address = clientIpAddressInputField.text;
            NetworkManager.Singleton.StartClient();
        });
    }
    public string GetLocalIPAddress()
    {
        string localIP = string.Empty;
        try
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork && !IPAddress.IsLoopback(ip))
                {
                    localIP = ip.ToString();
                    break;
                }
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error fetching local IP address: " + ex.Message);
        }

        return localIP;
    }
}
