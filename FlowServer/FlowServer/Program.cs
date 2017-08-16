using System.IO;
using Microsoft.AspNetCore.Hosting;
using FlowServer.Helper;

namespace FlowServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();
            LogHelper.Info("服务开启！！！！！");
            host.Run();
        }
    }
}