using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace WebViewForm
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var builder = WebHost
                .CreateDefaultBuilder(args)
                .UseUrls("http://127.0.0.1:0")
                .UseKestrel()
                .UseStartup<Startup>();
            var app = builder.Build();
            app.RunAsync();

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(app));
        }
    }
}