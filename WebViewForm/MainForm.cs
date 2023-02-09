using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebViewForm
{
    public class MainForm : Form
    {
        public MainForm(IWebHost app)
        {
            var addresses = app.ServerFeatures.Get<IServerAddressesFeature>().Addresses;
            var address = new Uri(addresses.First());

            Size = new Size(800, 600);
            FormBorderStyle = FormBorderStyle.Sizable;
            Text = $"WebView - {address.Port}";

            var wb = new WebView2
            {
                AllowExternalDrop = true,
                Size = new Size(Width - 16, Height - 39),
                Source = address,
                Dock = DockStyle.Fill,
                Location = new Point(0, 0),
                TabIndex = 0,
                ZoomFactor = 1D
            };
            wb.CoreWebView2InitializationCompleted += (sender, e) =>
            {
                var webView = ((WebView2?)sender);
                if (e.IsSuccess)
                {
                    webView!.CoreWebView2.Settings.AreDevToolsEnabled = 
                    webView!.CoreWebView2.Settings.AreDefaultContextMenusEnabled = 
                    webView!.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = 
                    webView!.CoreWebView2.Settings.IsBuiltInErrorPageEnabled =
                    webView!.CoreWebView2.Settings.IsZoomControlEnabled =
                    webView!.CoreWebView2.Settings.IsStatusBarEnabled = 
                    webView!.CoreWebView2.Settings.IsPasswordAutosaveEnabled = false;
                }
            };

            Resize += (sender, e) =>
            {
                wb.Size = new Size(Width - 16, Height - 39);
            };

            Controls.Add(wb);
        }
    }
}
