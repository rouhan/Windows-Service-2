using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace WindowsService_HostAPI
{
    partial class SelfHostService : ServiceBase
    {
        public SelfHostService()
        {
            InitializeComponent();
        }

        public void RunService()
        {
            OnStart(new string[] { "1", "2" });
        }
        protected override void OnStart(string[] args)
        {
            LogHelper.Log($"Starting Service");

            var config = new HttpSelfHostConfiguration("http://localhost:8080");



            config.Routes.MapHttpRoute(
               name: "API",
               routeTemplate: "{controller}/{action}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );

            HttpSelfHostServer server = new HttpSelfHostServer(config);
            LogHelper.Log("Service Started");

            server.OpenAsync().Wait();
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
    }
}
