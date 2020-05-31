using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace WindowsService_HostAPI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;

            SelfHostService _selfHostService = new SelfHostService();

            _selfHostService.ServiceName = "WebAPI_Hosted";
             
            ServicesToRun = new ServiceBase[] 
            { 
                _selfHostService
            };
            ServiceBase.Run(ServicesToRun);

            //_selfHostService.RunService();
        }
    }
}
