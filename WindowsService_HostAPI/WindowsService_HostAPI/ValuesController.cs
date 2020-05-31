using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Web.Http;

namespace WindowsService_HostAPI
{
    public class ValuesController : ApiController
    {
        public String GetString()
        {
            string HostName = Dns.GetHostName();
            string IP;

            LogHelper.Log($"HostName [{HostName}] ");

            IP = GetLocalIPAddress();
            LogHelper.Log($"IP [{IP}] ");

            List<string> data = new List<string>();
            Dictionary<string, string> dData = new Dictionary<string, string>();
            dData.Add("HostName", HostName);
            dData.Add("Ip", IP);
            data.Add(HostName);
            data.Add(IP);
            
            string json = JsonConvert.SerializeObject(dData);
            LogHelper.Log($"json {json} ");

            return json;
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}