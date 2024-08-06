using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
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
            string localIP = GetLocalWifiIPAddress();
            Debug.Log("Local IP Address: " + localIP);
            string ipAddress = localIP;
            hostIpAddressInputField.text = localIP;
            ushort port = ushort.Parse(portInputField.text);

            var unityTransport = NetworkManager.Singleton.GetComponent<UnityTransport>();
            unityTransport.ConnectionData.Address = ipAddress;
            unityTransport.ConnectionData.Port = port;
            
            NetworkManager.Singleton.StartHost();
        });

        startClientButton.onClick.AddListener(() =>
        {
            string ipAddress = clientIpAddressInputField.text;
            ushort port = ushort.Parse(portInputField.text);

            var unityTransport = NetworkManager.Singleton.GetComponent<UnityTransport>();
            unityTransport.ConnectionData.Address = ipAddress;
            unityTransport.ConnectionData.Port = port;

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
    public string GetLocalWifiIPAddress()
    {
        foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
        {
            // Kiểm tra xem interface có phải là wireless và đang hoạt động
            if (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 && ni.OperationalStatus == OperationalStatus.Up)
            {
                foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                {
                    // Kiểm tra địa chỉ IPv4 và không phải là loopback
                    if (ip.Address.AddressFamily == AddressFamily.InterNetwork && !IPAddress.IsLoopback(ip.Address))
                    {
                        return ip.Address.ToString();
                    }
                }
            }
        }
        return "No Wi-Fi network found.";
    }
}
