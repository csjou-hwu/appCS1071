using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
// https://stackoverflow.com/questions/14267010/how-to-create-self-signed-ssl-certificate-for-test-purposes
// OpenSSL 產生 pfx file
// https://stackoverflow.com/questions/45205863/kestrel-usehttps-method-signature-changed-in-net-core-2


namespace wk0901
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel(options =>
                options.Listen(IPAddress.Any, 443, listenOptions => listenOptions.UseHttps("mycert.pfx", "123456")))
                .UseStartup<Startup>()
                .Build();
    }
}
