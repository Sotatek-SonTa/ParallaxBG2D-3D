using System.Net;
using UnityEngine;

public class IPAddressFetcher : MonoBehaviour
{
    void Start()
    {
        string localIP = GetLocalIPAddress();
        Debug.Log("Local IP Address: " + localIP);
    }

    public string GetLocalIPAddress()
    {
        string localIP = string.Empty;
        try
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
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